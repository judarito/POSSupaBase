using CommonBase.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.ProductCategoryService
{
    public interface IProductCategoryService: InterfaceBaseCrud<ProductCategory>
    {
        Task<List<ProductCategory>> GetByName(string name);
    }
}
