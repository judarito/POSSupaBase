using CommonBase.Services.CacheService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.CacheService
{
    public interface ICacheService
    {
        TipoCache EntityCache { get; set; }
        void LoadDataInCache();
        Task<object> GetCache(string key);
    }
}
