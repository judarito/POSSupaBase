using AutoMapper;
using CommonBase.Dtos.Productos;
using CommonBase.Dtos.Terceros;
using CommonBase.Models.Productos;
using CommonBase.Models.Terceros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class TercerosProfile:Profile
    {
        public TercerosProfile() {
            CreateMap<TercerosDto, Terceros>().ReverseMap();
        }
    }
}
