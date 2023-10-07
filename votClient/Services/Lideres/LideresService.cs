using votClient.Models;
using static System.Net.WebRequestMethods;
using votClient.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;

namespace votClient.Services.Lideres
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

        public async Task<Lider> GetById(int? id)
        {
            var result = await _http.GetFromJsonAsync<Lider[]>($"Lideres/GetById/{id}");
            return result.FirstOrDefault();
        }

        public async Task<HttpResponseMessage> Update(Lider lider) => await _http.PutAsJsonAsync("Lideres/Update", lider);
    }
}
