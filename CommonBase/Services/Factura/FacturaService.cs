using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos;
using CommonBase.Dtos.Facturas;
using CommonBase.Models.CabeceraFactura;
using CommonBase.Models.DetalleFactura;
using CommonBase.Models.UserModel;
using System.Text.Json;

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
            try
            {
                 await _client.Rpc("deletefactura", new Dictionary<string, object> { { "idfactura", IdFactura }, });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<FacturasModel> GetAll(int? from, int? to, string? searchCrieria, DateTime DtInicio, DateTime DtFin)
        {
            FacturasModel facturaResult = new FacturasModel();

            var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");
            try
            {


                var result = await _client.Rpc("getallfactura", new Dictionary<string, object> {
                                                                                                    { "pagesize", from },
                                                                                                    { "paso", to },
                                                                                                    { "criteria", searchCrieria },
                                                                                                    { "dtinicio", DtInicio.ToString("yyyy-MM-dd") },
                                                                                                    { "dtfin", DtFin.ToString("yyyy-MM-dd") },
                                                                                                    { "idtenant", UserInfo.TenantId },
                                                                                               });


                if (result != null)
                {
                    string content = result.Content.ToString().Replace("'", "");
                    facturaResult = JsonSerializer.Deserialize<FacturasModel>(content);
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return facturaResult;
        }

        public async Task<FacturaModel> GetById(int IdFactura)
        {
            FacturaModel facturaResult = new FacturaModel();
            try
            {
                var result = await _client.Rpc("getfactura", new Dictionary<string, object> {{ "idfactura", IdFactura },});

                if (result != null)
                {
                    string content = result.Content.ToString().Replace("'", "");
                    facturaResult = JsonSerializer.Deserialize<FacturaModel>(content);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return facturaResult;
        }
        public async Task SaveOrUpdate(FacturaSaveModel facturaDto)
        {
             var UserInfo = await _localStorage.GetItemAsync<UserInfoLocalStorage>("USER_INFO");

            try
            {
                string jsonData=  JsonSerializer.Serialize<FacturaSaveModel>(facturaDto);
                var result = await _client.Rpc("insertfactura", new Dictionary<string, object> {
                                                                                                { "jsonfactura", jsonData },
                                                                                                { "idtenant", UserInfo.TenantId },
                                                                                             });

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
    }
}
