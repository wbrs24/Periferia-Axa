using AutoMapper;
using DataAccess.Model.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolViewModel>()
             .ForMember(dest =>
                 dest.IdRol,
                 opt => opt.MapFrom(src => src.IdRol)
             )
             .ForMember(dest =>
                 dest.Description,
                 opt => opt.MapFrom(src => src.Description)
             )
             .ReverseMap();
        }
    }
}
