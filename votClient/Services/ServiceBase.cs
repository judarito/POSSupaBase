namespace votClient.Services
{
    public class ServiceBase
    {
        private HttpClient _http;

        public ServiceBase(HttpClient http)
        {
            _http = http;
        }
    }
}
