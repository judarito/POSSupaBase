using AutoMapper;
using CommonBase.Dtos.Facturas;
using CommonBase.Dtos.TipoPago;
using CommonBase.Models.TipoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class DetalleFacturaSaveProfile:Profile
    {
        public DetalleFacturaSaveProfile() {
            CreateMap<DetalleFacturaSaveUIModel, DetalleFacturaSaveModel>().ReverseMap();
        }
    }
}
