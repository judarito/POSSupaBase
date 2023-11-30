using AutoMapper;
using CommonBase.Dtos.ProductCategory;
using CommonBase.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Profiles
{
    public class UnidadMedidaProfile : Profile
    {
        public UnidadMedidaProfile() {
            CreateMap<ProductCategoryDto, ProductCategory>().ReverseMap();
        }
    }
}
