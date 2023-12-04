using AutoMapper;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Authentication;
using System.Diagnostics.Eventing.Reader;

namespace PetCareAndAdoption.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserInfo, UserInfoModel>().ReverseMap();
            CreateMap<SignUpModel, UserInfo>()
          .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
          .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.PhoneNumber))
          .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
          .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
