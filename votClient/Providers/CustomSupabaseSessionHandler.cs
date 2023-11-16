using Supabase.Gotrue.Interfaces;
using Supabase.Gotrue;
using Blazored.SessionStorage;
using CommonBase.Services.User;

namespace votClient.Providers
{
    public class CustomSupabaseSessionHandler: IGotrueSessionPersistence<Session>
    {
        private readonly IUserService _userService;
        private readonly ISessionStorageService _localStorage;
        private readonly ILogger<CustomSupabaseSessionHandler> _logger;
        private const string SessionKey = "SUPABASE_SESSION";
        private const string UserInfoKey = "SUPABASE_USERINFO";

        public CustomSupabaseSessionHandler(
           
            ISessionStorageService localStorage,
            ILogger<CustomSupabaseSessionHandler> logger
        )
        {
            //_userService = userService;
             _localStorage = localStorage;
            _logger = logger;
        }

        public async void DestroySession()
        {
            await _localStorage.RemoveItemAsync(SessionKey);
            await _localStorage.RemoveItemAsync(UserInfoKey);
        }

        public async void SaveSession(Session session)
        {
            await _localStorage.SetItemAsync(SessionKey, session);
            //var UserInfo = _userService.GetUserByIdSupabase(Guid.Parse(session?.User?.Id));
            //await _localStorage.SetItemAsync(UserInfoKey, UserInfo);
        }

        public Session? LoadSession()
        {
            var session = _localStorage.GetItemAsync<Session>(SessionKey).Result;
            return session?.ExpiresAt() <= DateTime.Now ? null : session;
        }
    }
}
