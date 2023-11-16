using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Supabase.Gotrue;
using System.Security.Claims;
using System.Text.Json;

namespace votClient.Providers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {


        private readonly Supabase.Client _client;

        private readonly ILogger<CustomAuthStateProvider> _logger;
        private readonly ISessionStorageService _localStorage;

        public CustomAuthStateProvider(
            Supabase.Client client,
            ISessionStorageService localStorage,
            ILogger<CustomAuthStateProvider> logger
        )
        {
            logger.LogInformation("------------------- CONSTRUCTOR -------------------");
            _client = client;
            _logger = logger;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _logger.LogInformation("------------------- GetAuthenticationStateAsync -------------------");

            var sessionData = await _localStorage.GetItemAsync<Session>("SUPABASE_SESSION");
                                  
            Session currentSession = null;
            if (sessionData != null)
            {
                currentSession = sessionData?.ExpiresAt() <= DateTime.Now ? null : sessionData;
            }
            
            // Sets client auth and connects to realtime (if enabled)
            if (currentSession == null)
            {
                await _client.InitializeAsync();
                currentSession = _client.Auth.CurrentSession;
            }


            var identity = new ClaimsIdentity();
            // _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(currentSession?.AccessToken))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(currentSession.AccessToken), "jwt");
                // _http.DefaultRequestHeaders.Authorization =
                //     new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
