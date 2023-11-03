using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Net.Http.Json;
using CommonBase.Models;
using CommonBase.Models.Votantes;

namespace CommonBase.Services.Votantes
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

        public async Task<DataPaginationVotantes> GetByCriteria(string criteria, int? Limit, int? Offset) => await _http.GetFromJsonAsync<DataPaginationVotantes>($"Votantes/GetAllByCriteria/{criteria}/{Limit}/{Offset}");

        public async Task<Votante> GetById(int? id) => await _http.GetFromJsonAsync<Votante>($"Votantes/GetById/{id}");

        public async Task<DataPaginationVotantes> GetPaginationAll(int? Limit, int? Offset) => await _http.GetFromJsonAsync<DataPaginationVotantes>($"Votantes/GetAllAPagingsync/{Limit}/{Offset}");

        public async Task<HttpResponseMessage> Update(Votante votante) => await _http.PutAsJsonAsync("Votantes/Update", votante);
    }
}
