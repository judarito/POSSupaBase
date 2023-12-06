using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.EstadoEntrega;
using CommonBase.Dtos.TipoPago;
using CommonBase.Models.EstadoEntrega;
using CommonBase.Models.TipoPago;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.EstadoEntregaService
{
    public class EstadoEntregaService : ServiceBase<EstadoEntrega, EstadoEntregaDto>
    {
        public EstadoEntregaService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
