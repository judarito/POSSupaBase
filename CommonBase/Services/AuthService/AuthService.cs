using Blazored.SessionStorage;
using CommonBase.Models.UserModel;
using CommonBase.Services.User;
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
        private readonly IUserService _userService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            Supabase.Client client,
            AuthenticationStateProvider customAuthStateProvider,
            ISessionStorageService localStorage,
            IUserService userService,
            ILogger<AuthService> logger
        )
        {
            _client = client;
            _customAuthStateProvider = customAuthStateProvider;
            _localStorage = localStorage;
            _logger = logger;
            _userService=userService;
        }

        public async Task Login(string email, string password)
        {
            var session = await _client.Auth.SignIn(email, password);
            var userinfo= await _userService.GetUserByIdSupabase(Guid.Parse(session?.User.Id));
            if (userinfo != null)
            {
                _localStorage.SetItemAsync("USER_INFO", new UserInfoLocalStorage() { DisplayName= userinfo.DisplayName,TenantId= userinfo.idTenant });
            }
            await _customAuthStateProvider.GetAuthenticationStateAsync();
        }

        public async Task Logout()
        {
            await _client.Auth.SignOut();
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.RemoveItemAsync("USER_INFO");
            await _localStorage.RemoveItemAsync("SUPABASE_SESSION");
            await _customAuthStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<Supabase.Gotrue.User?> GetUser()
        {
            var session = await _client.Auth.RetrieveSessionAsync();
            return session?.User;
        }
    }
}
