using System.Net.Http.Json;
using System.Text.Json;
using CommonBase.Models;
using CommonBase.Models.Login;


namespace CommonBase.Services.Login
{
    public class LoginService : ServiceBase, ILoginService
    {
        private HttpClient _http;

        public LoginService(HttpClient http) : base(http)
        {
            _http = http;
        }

        public async Task<SessionResponse> Login(SessionRequest? session) {
            var response= await _http.PostAsJsonAsync("Session/login", session);
              using var responseStream = await response.Content.ReadAsStreamAsync();
            SessionResponse sessionResponse = await JsonSerializer.DeserializeAsync<SessionResponse>(responseStream);
            return sessionResponse;
        }  
    }
}
