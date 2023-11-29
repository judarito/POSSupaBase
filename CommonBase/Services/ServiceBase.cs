using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos;
using CommonBase.Models;
using CommonBase.Models.ProductCategory;
using CommonBase.Models.UserModel;
using Postgrest.Models;
using Postgrest.Responses;
using Supabase;
using static Postgrest.Constants;

namespace CommonBase.Services
{
    public class ServiceBase<T, TDto>  : InterfaceBaseCrud<TDto> 
        where T : BaseModelApp, new()
        where TDto : DtosBase, new()
    {
        private readonly Supabase.Client _client;
        private readonly ISessionStorageService _localStorage;
        private readonly IMapper _mapper;
        private Client client;

        public ServiceBase(Client client)
        {
            this.client = client;
        }

        public ServiceBase(Supabase.Client client, IMapper mapper,ISessionStorageService localStorage)
        {
            _client = client;
            _mapper = mapper;
            _localStorage = localStorage;
            


        }

        public async Task Delete(int id)
        {
            await _client.From<T>()
              .Where(x => x.Id == id)
              .Delete();
        }

        public async Task<List<TDto>> GetAll(int? from, int? to, string? searchCrieria)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            var modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                                    ? await _client.From<T>()
                                              .Select("*")
                                              .Range((int)from, (int)to)
                                              .Where(x=> x.IdTenant== UserInfo.TenantId)
                                              .Order(x => x.Id, Ordering.Descending)
                                              .Get()
                                    : await _client.From<T>()
                                              .Select("*")
                                              .Where(x => x.IdTenant == UserInfo.TenantId)
                                              .Filter(x=> x.Name, Operator.ILike, $"%{searchCrieria}%")
                                              .Range((int)from, (int)to)
                                              .Order(x => x.Id, Ordering.Descending)
                                              .Get();

            var mapModel=this._mapper.Map<List<TDto>>(modeledResponse.Models);
            return mapModel;
        }

        public async Task<int> GetCount(string? searchCrieria)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            var modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                   ? await _client.From<T>().Where(x => x.IdTenant == UserInfo.TenantId).Count(Postgrest.Constants.CountType.Exact)
                   : await _client.From<T>().Where(x => x.IdTenant == UserInfo.TenantId).Filter(x => x.Name, Operator.Like, $"%{searchCrieria}%").Count(Postgrest.Constants.CountType.Exact);
            
            return Convert.ToInt32(modeledResponse);
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
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            Entity.IdTenant = UserInfo.TenantId;
             var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Insert(mapModel);
        }

        public async Task Update(TDto Entity)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            Entity.IdTenant = UserInfo.TenantId;
            var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Upsert(mapModel);
        }
    }
}
