using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.ProductCategory;
using CommonBase.Dtos.Productos;
using CommonBase.Models.ProductCategory;
using CommonBase.Models.Productos;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.ProductosService
{
    public class ProductosService : ServiceBase<Productos, ProductosDto>
    {
        public ProductosService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
