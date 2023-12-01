using AutoMapper;
using CommonBase.Dtos.Productos;
using CommonBase.Models.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class ProductosProfile : Profile
    {   
        public ProductosProfile() {
            CreateMap<ProductosDto, Productos>().ReverseMap();
        }
        
    }
}
