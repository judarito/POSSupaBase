using AutoMapper;
using CommonBase.Dtos.Productos;
using CommonBase.Dtos.TipoPago;
using CommonBase.Models.Productos;
using CommonBase.Models.TipoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class TipoPagoProfile: Profile
    {
        public TipoPagoProfile() {
            CreateMap<TipoPagoDto, TipoPago>().ReverseMap();
        }
    }
}
