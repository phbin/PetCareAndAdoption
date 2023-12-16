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
          .ForMember(dest => dest.district, opt => opt.MapFrom(src => src.District))
          .ForMember(dest => dest.province, opt => opt.MapFrom(src => src.Province))
          .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password));

            CreateMap<UpdateUserModel, UserInfo>()
         .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
         .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.userID))
         .ForMember(dest => dest.district, opt => opt.MapFrom(src => src.district))
         .ForMember(dest => dest.province, opt => opt.MapFrom(src => src.province))
         .ForMember(dest => dest.avatar, opt => opt.MapFrom(src => src.avatar));

            CreateMap<Species, PetSpeciesModel>().ReverseMap();
     
            CreateMap<Breeds, PetBreedsModel>().ReverseMap();
            CreateMap<PostAdoptModel, PetPosts>().ReverseMap();
            CreateMap<ImageModel, ImagePost>()
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.image));
        }
    }
}
