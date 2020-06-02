using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.AccountViewModel;

namespace DataAccess.Model.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoggedUserViewModel>()
             .ForMember(dest =>
                 dest.IdUser,
                 opt => opt.MapFrom(src => src.IdUser)
             )
             .ForMember(dest =>
                 dest.IdNumber,
                 opt => opt.MapFrom(src => src.IdNumber)
             )
             .ForMember(dest =>
                 dest.Name,
                 opt => opt.MapFrom(src => src.Name)
             )
             .ForMember(dest =>
                 dest.SureName,
                 opt => opt.MapFrom(src => src.SureName)
             )
             .ForMember(dest =>
                 dest.Email,
                 opt => opt.MapFrom(src => src.Email)
             )
             .ForMember(dest =>
                 dest.State,
                 opt => opt.MapFrom(src => src.State)
             )
             .ForMember(dest =>
                 dest.Rols,
                 opt => opt.MapFrom(src => src.Rols)
             )
             .ReverseMap();
        }
    }
}
