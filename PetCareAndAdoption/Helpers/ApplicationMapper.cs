using AutoMapper;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Authentication;
using PetCareAndAdoption.Models.Pets;
using PetCareAndAdoption.Models.Posts;

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
            CreateMap<Species, PetSpeciesModel>().ReverseMap();
     
            CreateMap<Breeds, PetBreedsModel>().ReverseMap();
            CreateMap<Posts, PostAdoptModel>().ReverseMap();

        }
    }
}
