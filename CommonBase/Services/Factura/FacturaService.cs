using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos;
using CommonBase.Models.CabeceraFactura;
using CommonBase.Models.DetalleFactura;
using CommonBase.Models.UserModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.Factura
{
    public class FacturaService : IFacturaService
    {
        private readonly Supabase.Client _client;
        private readonly ISessionStorageService _localStorage;
        private readonly IMapper _mapper;
        public FacturaService(Supabase.Client client,
                            IMapper mapper,
                            ISessionStorageService localStorage)
        {
            _client = client;
            _mapper = mapper;
            _localStorage = localStorage;
        }
        public async Task Delete(int IdFactura)
        {
            await _client.From<DetalleFactura>()
              .Where(x => x.Id == IdFactura)
              .Delete();

            await _client.From<CabeceraFactura>()
              .Where(x => x.Id == IdFactura)
              .Delete();
        }

        public Task<List<FacturaDto>> GetAll(int? from, int? to, string? searchCrieria)
        {
            throw new NotImplementedException();
        }

        public Task<FacturaDto> GetById(int IdFactura)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(string? searchCrieria)
        {
            throw new NotImplementedException();
        }

        public async Task Save(FacturaDto facturaDto)
        {
            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            facturaDto.CabeceraFactura.IdTenant = UserInfo.TenantId;
            var mapModelCabecera = this._mapper.Map<CabeceraFactura>(facturaDto.CabeceraFactura);

            var newCabeceraFactura = await _client.From<CabeceraFactura>().Insert(mapModelCabecera);

            CabeceraFactura NewIdFacura = JsonConvert.DeserializeObject<CabeceraFactura>(newCabeceraFactura.Content);

            facturaDto.DetalleFactura.All(c =>
                {
                    c.IdTenant = UserInfo.TenantId;
                    c.IdCabeceraFactura = NewIdFacura.Id;
                    return true;
                });

            facturaDto.DetalleFactura.ForEach(async item =>
            {
                var mapModelDetalle = this._mapper.Map<DetalleFactura>(item);
                await _client.From<DetalleFactura>().Insert(mapModelDetalle);
            });


        }

        public async Task Update(FacturaDto facturaDto)
        {

            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            facturaDto.CabeceraFactura.IdTenant = UserInfo.TenantId;
            var mapModelCabecera = this._mapper.Map<CabeceraFactura>(facturaDto.CabeceraFactura);
            await _client.From<CabeceraFactura>().Update(mapModelCabecera);

            facturaDto.DetalleFactura.All(c =>
            {
                c.IdTenant = UserInfo.TenantId;
                return true;
            });

            facturaDto.DetalleFactura.ForEach(async item =>
            {
                var mapModelDetalle = this._mapper.Map<DetalleFactura>(item);
                await _client.From<DetalleFactura>().Update(mapModelDetalle);
            });



        }
    }
}
