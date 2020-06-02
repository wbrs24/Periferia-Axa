using AutoMapper;
using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
             .ForMember(dest =>
                 dest.IdCategory,
                 opt => opt.MapFrom(src => src.IdCategory)
             )
             .ForMember(dest =>
                 dest.Description,
                 opt => opt.MapFrom(src => src.Description)
             )
             .ReverseMap();
        }
    }
}
