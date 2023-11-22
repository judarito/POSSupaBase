﻿using AutoMapper;
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

        public async Task<List<TDto>> GetAll(int? from, int? to)
        {
            var modeledResponse = await  _client.From<T>().Select("*").Range((int)from, (int)to).Get();
            var mapModel=this._mapper.Map<List<TDto>>(modeledResponse.Models);
            return mapModel;
        }

        public async Task<int> GetCount()
        {
            var modeledResponse = await _client.From<T>().Count(Postgrest.Constants.CountType.Exact);
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
            var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Insert(mapModel);
        }

        public async Task Update(TDto Entity)
        {
            var mapModel = this._mapper.Map<T>(Entity);
            await _client.From<T>().Upsert(mapModel);
        }
    }
}
