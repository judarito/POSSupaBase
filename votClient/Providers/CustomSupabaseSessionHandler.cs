using Supabase.Gotrue.Interfaces;
using Supabase.Gotrue;
using Blazored.SessionStorage;

namespace votClient.Providers
{
    public class CustomSupabaseSessionHandler: IGotrueSessionPersistence<Session>
    {
        private readonly ISessionStorageService _localStorage;
        private readonly ILogger<CustomSupabaseSessionHandler> _logger;
        private const string SessionKey = "SUPABASE_SESSION";

        public CustomSupabaseSessionHandler(
            ISessionStorageService localStorage,
            ILogger<CustomSupabaseSessionHandler> logger
        )
        {
            logger.LogInformation("------------------- CONSTRUCTOR -------------------");
            _localStorage = localStorage;
            _logger = logger;
        }

        public async void DestroySession()
        {
            _logger.LogInformation("------------------- SessionDestroyer -------------------");
            await _localStorage.RemoveItemAsync(SessionKey);
        }

        public async void SaveSession(Session session)
        {
            _logger.LogInformation("------------------- SessionPersistor -------------------");
            await _localStorage.SetItemAsync(SessionKey, session);
        }

        public Session? LoadSession()
        {
            _logger.LogInformation("------------------- SessionRetriever -------------------");

            var session = _localStorage.GetItemAsync<Session>(SessionKey).Result;
            return session?.ExpiresAt() <= DateTime.Now ? null : session;
        }
    }
}
