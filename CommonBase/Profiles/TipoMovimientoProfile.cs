using AutoMapper;
using CommonBase.Dtos.Productos;
using CommonBase.Dtos.TipoMovimiento;
using CommonBase.Models.Productos;
using CommonBase.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class TipoMovimientoProfile:Profile
    {
        public TipoMovimientoProfile() {
            CreateMap<TipoMovimientoDto, TipoMovimiento>().ReverseMap();
        }
    }
}
