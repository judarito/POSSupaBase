using CommonBase.Models;
using System.Net.Http.Json;


namespace CommonBase.Services.Lideres
{
    public class LideresService : ILideresService
    {
        private HttpClient _http;

        public LideresService(HttpClient http)
        {
            _http=http;
        }
        public async Task<HttpResponseMessage> Create(Lider lider) => await _http.PostAsJsonAsync("Lideres/Create", lider);

        public async Task<HttpResponseMessage> Delete(int id) => await _http.DeleteAsync($"Lideres/DeleteById/{id}");

        public async Task<Lider[]> GetAll() => await _http.GetFromJsonAsync<Lider[]>("Lideres/GetAlls");

        public async Task<Lider> GetById(int? id) => await _http.GetFromJsonAsync<Lider>($"Lideres/GetById/{id}");

        public async Task<HttpResponseMessage> Update(Lider lider) => await _http.PutAsJsonAsync("Lideres/Update", lider);
    }
}
