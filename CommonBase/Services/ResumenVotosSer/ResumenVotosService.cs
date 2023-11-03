using System.Net.Http.Json;
using CommonBase.Models;
using CommonBase.Models.ResumenVotos;
using static System.Net.WebRequestMethods;

namespace CommonBase.Services.ResumenVotosSer
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
