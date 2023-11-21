using CommonBase.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services
{
    public interface InterfaceBaseCrud<TModel> where TModel : class
    {
        Task<List<TModel>> GetAll(int? from,int? to);
        Task Save(TModel Entity);
        Task Update(TModel Entity);
        Task Delete(int id);
        Task<TModel> GetById(int id);
    }
}
