using AutoMapper;
using CommonBase.Dtos.CabeceraFactura;
using CommonBase.Dtos.TipoMovimiento;
using CommonBase.Models.CabeceraFactura;
using CommonBase.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class CabeceraFacturaProfile: Profile
    {
        public CabeceraFacturaProfile() {
            CreateMap<CabeceraFacturaDto, CabeceraFactura>().ReverseMap();
        }
    }
}
