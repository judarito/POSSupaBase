using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.ProductCategory;
using CommonBase.Models.ProductCategory;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Postgrest.Constants;

namespace CommonBase.Services.ProductCategoryService
{
    public class ProductCategoryService : ServiceBase<ProductCategory, ProductCategoryDto>
    {
        public ProductCategoryService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
