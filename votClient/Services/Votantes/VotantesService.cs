using Microsoft.VisualBasic;
using System.Net.Http.Json;
using votClient.Models;

namespace votClient.Services.Votantes
{
    public class VotantesService : IVotantesService
    {
        private HttpClient _http;

        public VotantesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> Create(Votante votante) => await _http.PostAsJsonAsync("Votantes/Create", votante);

        public async Task<HttpResponseMessage> Delete(int id) => await _http.DeleteAsync($"Votantes/DeleteById/{id}");

        public async Task<Votante[]> GetAll() => await _http.GetFromJsonAsync<Votante[]>("Votantes/GetAlls");

        public async Task<Votante[]> GetByCeculaOrNombre(string criteria) => await _http.GetFromJsonAsync<Votante[]>($"Votantes/GetByCedulaAsync/{criteria}");

        public async Task<Votante> GetById(int? id) => await _http.GetFromJsonAsync<Votante>($"Votantes/GetById/{id}");

        public async Task<HttpResponseMessage> Update(Votante votante) => await _http.PutAsJsonAsync("Votantes/Update", votante);
    }
}
