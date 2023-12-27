using Blazored.SessionStorage;
using CommonBase.Dtos.Facturas;
using CommonBase.Dtos.ProductCategory;
using CommonBase.Services.CacheService.Enum;
using CommonBase.Services.Factura;
using CommonBase.Services.ProductCategoryService;


namespace CommonBase.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly ISessionStorageService _localStorage;
        private readonly IFacturaService _facturaService;
        private readonly CommonBase.Services.ProductCategoryService.ProductCategoryService _productCategoryService;
        private Timer _timer;
        public TipoCache EntityCache { get ; set ; }

        public CacheService(ISessionStorageService localStorage,
                            IFacturaService facturaService,
                            CommonBase.Services.ProductCategoryService.ProductCategoryService productCategoryService) 
        {
            _localStorage=localStorage;
            _facturaService = facturaService;
            _productCategoryService = productCategoryService;
            EntityCache = TipoCache.All;
        }

        public void LoadDataInCache()
        {
            _timer = new Timer(new TimerCallback(LoadDataInCache), null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private async void LoadDataInCache(object state)
        {

            if (EntityCache==TipoCache.AditionalData || EntityCache==  TipoCache.All)
            {
                var adCliente = await _facturaService.GetAditionalData("CLIENTE");
                var adProveedor = await _facturaService.GetAditionalData("PROVEEDOR");

                await _localStorage.RemoveItemAsync("adCLIENTE");
                await _localStorage.RemoveItemAsync("adPROVEEDOR");
                await _localStorage.SetItemAsync("adCLIENTE", adCliente);
                await _localStorage.SetItemAsync("adPROVEEDOR", adProveedor);
            }

            if (EntityCache == TipoCache.CatProductos || EntityCache == TipoCache.All)
            {
                var productCategories = await _productCategoryService.GetAll(0, 1000, "", null);

                await _localStorage.RemoveItemAsync("CATPROD");
                await _localStorage.SetItemAsync("CATPROD", productCategories);
            }


            ((Timer)state).Change(Timeout.Infinite, Timeout.Infinite);
        }
        public void Dispose()
        {
            //maybe to a "final" call
            _timer.Dispose();
        }

        public async Task<object> GetCache(string key)
        {
            if (EntityCache == TipoCache.AditionalData)
            {
                var AdInfo = await _localStorage.GetItemAsync<DatosAdicionalesFactura>(key);
                return AdInfo;
            }

            if (EntityCache == TipoCache.CatProductos)
            {
                var AdInfo = await _localStorage.GetItemAsync<List<ProductCategoryDto>>(key);
                return AdInfo;
            }

            return null;
        }
    }
}
