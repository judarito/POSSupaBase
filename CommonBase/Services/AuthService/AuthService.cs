using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.AuthService
{
    public class AuthService
    {
        private readonly Supabase.Client _client;
        private readonly AuthenticationStateProvider _customAuthStateProvider;
        private readonly ISessionStorageService _localStorage;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            Supabase.Client client,
            AuthenticationStateProvider customAuthStateProvider,
            ISessionStorageService localStorage,
            ILogger<AuthService> logger
        )
        {
            _client = client;
            _customAuthStateProvider = customAuthStateProvider;
            _localStorage = localStorage;
            _logger = logger;
        }

        public async Task Login(string email, string password)
        {
            var session = await _client.Auth.SignIn(email, password);

            await _customAuthStateProvider.GetAuthenticationStateAsync();
        }

        public async Task Logout()
        {
            await _client.Auth.SignOut();
            await _localStorage.RemoveItemAsync("token");
            await _customAuthStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<Supabase.Gotrue.User?> GetUser()
        {
            var session = await _client.Auth.RetrieveSessionAsync();
            return session?.User;
        }
    }
}
