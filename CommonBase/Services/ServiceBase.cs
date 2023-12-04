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

        public async Task<List<TDto>> GetAll(int? from, int? to, string? searchCrieria,Dictionary<string, string> AditionalParmFilter)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            ModeledResponse<T> modeledResponse = null;
            if (AditionalParmFilter == null)
            {
                modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                                  ? await _client.From<T>()
                                            .Select("*")
                                            .Range((int)from, (int)to)
                                            .Where(x => x.IdTenant == UserInfo.TenantId)
                                            .Order(x => x.Id, Ordering.Descending)
                                            .Get()
                                  : await _client.From<T>()
                                            .Select("*")
                                            .Where(x => x.IdTenant == UserInfo.TenantId)
                                            .Filter(x => x.Name, Operator.ILike, $"%{searchCrieria}%")
                                            .Range((int)from, (int)to)
                                            .Order(x => x.Id, Ordering.Descending)
                                            .Get();
            }
            else {
                if (AditionalParmFilter?.Count > 0)
                {
                    modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                                 ? await _client.From<T>()
                                           .Select("*")
                                           .Range((int)from, (int)to)
                                           .Where(x => x.IdTenant == UserInfo.TenantId)
                                           .Match(AditionalParmFilter)
                                           .Order(x => x.Id, Ordering.Descending)
                                           .Get()
                                 : await _client.From<T>()
                                           .Select("*")
                                           .Where(x => x.IdTenant == UserInfo.TenantId)
                                           .Filter(x => x.Name, Operator.ILike, $"%{searchCrieria}%")
                                           .Match(AditionalParmFilter)
                                           .Range((int)from, (int)to)
                                           .Order(x => x.Id, Ordering.Descending)
                                           .Get();
                }
            }
           

            var mapModel=this._mapper.Map<List<TDto>>(modeledResponse.Models);
            return mapModel;
        }

        public async Task<int> GetCount(string? searchCrieria, Dictionary<string, string> AditionalParmFilter)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");
           int modeledResponse = 0;
            if (AditionalParmFilter == null)
            {
                modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                  ? await _client.From<T>()
                       .Where(x => x.IdTenant == UserInfo.TenantId)
                       .Count(Postgrest.Constants.CountType.Exact)
                  : await _client.From<T>()
                       .Where(x => x.IdTenant == UserInfo.TenantId)
                       .Filter(x => x.Name, Operator.Like, $"%{searchCrieria}%")
                       .Count(Postgrest.Constants.CountType.Exact);
            }
            else {
                if(AditionalParmFilter?.Count > 0)
                {
                    modeledResponse = String.IsNullOrWhiteSpace(searchCrieria)
                     ? await _client.From<T>()
                          .Where(x => x.IdTenant == UserInfo.TenantId)
                          .Match(AditionalParmFilter)
                          .Count(Postgrest.Constants.CountType.Exact)
                     : await _client.From<T>()
                          .Where(x => x.IdTenant == UserInfo.TenantId)
                          .Filter(x => x.Name, Operator.Like, $"%{searchCrieria}%")
                          .Match(AditionalParmFilter)
                          .Count(Postgrest.Constants.CountType.Exact);
                }
               
            }
            
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

            //var model = await _client
            //              .From<T>()
            //              .Where(x => x.Id == Entity.Id)
            //              .Single();

            //string UrlBase = model.BaseUrl;
            Entity.IdTenant = UserInfo.TenantId;

            var mapModel = this._mapper.Map<T>(Entity);
            //model.BaseUrl = UrlBase;
            //await model.Update<T>();
            await _client.From<T>().Update(mapModel);
        }
    }
}
