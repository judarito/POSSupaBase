using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.TipoMovimiento;
using CommonBase.Dtos.TipoPago;
using CommonBase.Models.TipoMovimiento;
using CommonBase.Models.TipoPago;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.TipoPagoService
{
    public class TipoPagoService : ServiceBase<TipoPago, TipoPagoDto>
    {
        public TipoPagoService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
