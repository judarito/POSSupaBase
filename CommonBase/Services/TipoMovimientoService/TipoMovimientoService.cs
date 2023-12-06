using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.TipoMovimiento;
using CommonBase.Dtos.UnidadMedida;
using CommonBase.Models.TipoMovimiento;
using CommonBase.Models.UnidadMedida;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.TipoMovimientoService
{
    public class TipoMovimientoService : ServiceBase<TipoMovimiento, TipoMovimientoDto>
    {
        public TipoMovimientoService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
