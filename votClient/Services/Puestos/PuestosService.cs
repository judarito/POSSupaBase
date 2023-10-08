using System.Net.Http.Json;
using votClient.Models;
using static System.Net.WebRequestMethods;

namespace votClient.Services.Puestos
{
    public class PuestosService : IPuestosService
    {
        private HttpClient _http;

        public PuestosService(HttpClient http)
        {
            _http = http;
        }
        public async Task<PuestoVotacion[]> GetAll() => await _http.GetFromJsonAsync<PuestoVotacion[]>("Puesto/GetAlls");

        public async Task<PuestoVotacion> GetById(int? id) => await _http.GetFromJsonAsync<PuestoVotacion>($"Puesto/GetById/{id}");
    }
}
