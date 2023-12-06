using AutoMapper;
using CommonBase.Dtos.EstadoEntrega;
using CommonBase.Dtos.Productos;
using CommonBase.Models.EstadoEntrega;
using CommonBase.Models.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class EstadoEntregaProfile: Profile
    {
        public EstadoEntregaProfile() {
            CreateMap<EstadoEntregaDto, EstadoEntrega>().ReverseMap();
        }
    }
}
