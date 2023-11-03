using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CommonBase.Shared.Services
{
    public class TokenServerAuthenticationStateProvider : AuthenticationStateProvider
    {
       private ISessionStorageService _sessionStorage;
        public TokenServerAuthenticationStateProvider(ISessionStorageService sessionStorage) {
            _sessionStorage = sessionStorage;
        }

        public async Task<string> GetTokenAsync() => await _sessionStorage.GetItemAsync<string>("jwt");
        public async Task<string> GetDisplayNamenAsync() => await _sessionStorage.GetItemAsync<string>("DisplayName");

        public async Task SetTokenAsync(string token)
        {
            if (token == null)
            {
                await  _sessionStorage.RemoveItemAsync("jwt");
            }
            else
            {
                await _sessionStorage.SetItemAsStringAsync("jwt", token);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetTokenAsync();
            var anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));


            // Not authenticated
            if (string.IsNullOrWhiteSpace(token))
            {
                return anonymousState;
            }

            var claims = ServiceExtensions.ParseClaimsFromJwt(token);
            // Checks the exp field of the token
            var expiry = claims.Where(claim => claim.Type.Equals("exp")).FirstOrDefault();
            if (expiry == null)
                return anonymousState;

            // The exp field is in Unix time
            var datetime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiry.Value));
            if (datetime.UtcDateTime <= DateTime.UtcNow)
                return anonymousState;

            var identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(ServiceExtensions.ParseClaimsFromJwt(token), "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task Logout()
        {
            await _sessionStorage.ClearAsync();
            //await _sessionStorage.RemoveItemAsync("jwt");
            //await _sessionStorage.RemoveItemAsync("UserName");
            //await _sessionStorage.RemoveItemAsync("DisplayName");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
