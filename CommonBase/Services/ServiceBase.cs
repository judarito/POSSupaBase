using CommonBase.Models;
using CommonBase.Models.ProductCategory;
using Postgrest.Models;

namespace CommonBase.Services
{
    public class ServiceBase<T>  : InterfaceBaseCrud<T> where T : BaseModelApp, new()
    {
        private readonly Supabase.Client _client;
        public ServiceBase(Supabase.Client client)
        {
            _client = client;
        }
        public async Task Delete(int id)
        {
            await _client.From<T>()
                .Where(x => x.Id == id)
                .Delete();
        }

        public async Task<List<T>> GetAll()
        {
            var modeledResponse = await _client.From<T>().Get();
            return modeledResponse.Models;
        }

        public async Task<T> GetById(int id)
        {
            var modeledResponse = await _client.From<T>()
               .Where(x => x.Id == id)
               .Get();
            return modeledResponse.Models.FirstOrDefault();
        }

        public async Task Save(T Entity)
        {
            await _client.From<T>().Insert(Entity);
        }

        public async Task Update(T Entity)
        {
            await _client.From<T>().Upsert(Entity);
        }
    }
}
