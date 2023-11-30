using AutoMapper;
using Blazored.SessionStorage;
using CommonBase.Dtos.UnidadMedida;
using CommonBase.Models.UnidadMedida;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.UnidadMedidaService
{
    public class UnidadMedidaService : ServiceBase<UnidadMedida, UnidadMedidaDto>
    {
        public UnidadMedidaService(Client client, IMapper mapper, ISessionStorageService localStorage) : base(client, mapper, localStorage)
        {
        }
    }
}
