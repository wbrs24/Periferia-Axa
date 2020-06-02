using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model.ViewModels;

namespace DataAccess.Model.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
             .ForMember(dest =>
                 dest.IdProduct,
                 opt => opt.MapFrom(src => src.IdProduct)
             )
             .ForMember(dest =>
                 dest.Name,
                 opt => opt.MapFrom(src => src.Name)
             )
             .ForMember(dest =>
                 dest.Description,
                 opt => opt.MapFrom(src => src.Description)
             )
             .ForMember(dest =>
                 dest.Price,
                 opt => opt.MapFrom(src => src.UnitPrice)
             )
             .ForMember(dest =>
                 dest.Quantity,
                 opt => opt.MapFrom(src => Convert.ToByte(src.Quantity))
             )
             .ForMember(dest =>
                 dest.State,
                 opt => opt.MapFrom(src => src.State ? "Available" : "Unavailable")
             )
             .ForMember(dest =>
                 dest.CreatedBy,
                 opt => opt.MapFrom(src => src.CreatedBy)
             )
             .ForMember(dest =>
                 dest.Categories,
                 opt => opt.MapFrom(src => src.Categories)
             )
             .ReverseMap();
        }
    }
}
