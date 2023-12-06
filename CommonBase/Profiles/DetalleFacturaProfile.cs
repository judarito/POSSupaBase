using AutoMapper;
using CommonBase.Dtos.CabeceraFactura;
using CommonBase.Dtos.DetalleFactura;
using CommonBase.Models.CabeceraFactura;
using CommonBase.Models.DetalleFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class DetalleFacturaProfile:Profile
    {
        public DetalleFacturaProfile() {
            CreateMap<DetalleFacturaDto, DetalleFactura>().ReverseMap();
        }
    }
}
