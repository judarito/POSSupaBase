using AutoMapper;
using CommonBase.Models;
using CommonBase.Models.ProductCategory;
using Postgrest.Models;
using Postgrest.Responses;
using Supabase;

namespace CommonBase.Services
{
    public class ServiceBase<T, TDto>  : InterfaceBaseCrud<TDto> 
        where T : BaseModelApp, new()
        where TDto : class
    {
        private readonly Supabase.Client _client;
        private readonly IMapper _mapper;
        private Client client;

        public ServiceBase(Client client)
        {
            this.client = client;
        }

        public ServiceBase(Supabase.Client client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _client.From<T>()
              .Where(x => x.Id == id)
              .Delete();
        }

        public async Task<List<TDto>> GetAll()
        {
            var modeledResponse = await _client.From<T>().Get();
            var mapModel=this._mapper.Map<List<TDto>>(modeledResponse.Models);
            return mapModel;
        }

        public async Task<TDto> GetById(int id)
        {
            var modeledResponse = await _client.From<T>()
                .Where(x => x.Id == id)
                .Get();

            var mapModel = this._mapper.Map<List<TDto>>(modeledResponse.Models);
            return mapModel.FirstOrDefault();
        }

        public async Task Save(TDto Entity)
        {
            var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Insert(mapModel);
        }

        public async Task Update(TDto Entity)
        {
            var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Upsert(mapModel);
        }
        /* public async Task Delete(int id)
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
}*/
    }
}
