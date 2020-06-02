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
    public class UserRegisterProfile : Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<User, RegisterViewModel>()
             .ForMember(dest =>
                 dest.IdNumber,
                 opt => opt.MapFrom(src => src.IdNumber)
             )
             .ForMember(dest =>
                 dest.IdType,
                 opt => opt.MapFrom(src => Convert.ToByte(src.IdType))
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
                 dest.BirthDate,
                 opt => opt.MapFrom(src => Convert.ToDateTime(src.BirthDate))
             )
             .ForMember(dest =>
                 dest.ContactNumber,
                 opt => opt.MapFrom(src => src.ContactNumber)
             )
             .ForMember(dest =>
                 dest.Email,
                 opt => opt.MapFrom(src => src.Email)
             )
             .ForMember(dest =>
                 dest.Password,
                 opt => opt.MapFrom(src => src.Password)
             )
             .ReverseMap();
        }
    }
}
