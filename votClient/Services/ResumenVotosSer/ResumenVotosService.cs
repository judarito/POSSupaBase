using System.Net.Http.Json;
using votClient.Models;
using votClient.Models.ResumenVotos;
using static System.Net.WebRequestMethods;

namespace votClient.Services.ResumenVotosSer
{
    public class ResumenVotosService : ServiceBase,IResumenVotosService
    {
        private HttpClient _http;
        public ResumenVotosService(HttpClient http) : base(http)
        {
            _http = http;
        }

        public async Task<ResumenVotosModel> GetResumenVotos() => await _http.GetFromJsonAsync<ResumenVotosModel>("ResumenVotos/GetAlls");
    }
}
