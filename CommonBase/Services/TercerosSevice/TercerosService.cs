using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.Terceros;
using CommonBase.Models.Terceros;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.TercerosSevice
{
    public class TercerosService : ServiceBase<Terceros, TercerosDto>
    {
        public TercerosService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
