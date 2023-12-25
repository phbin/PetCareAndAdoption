using AutoMapper;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Authentication;
using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Models.Pets;
using PetCareAndAdoption.Models.Posts;
using PetCareAndAdoption.Models.RequestPost;
using UserInfoModel = PetCareAndAdoption.Models.UserInfoModel;
using UserRequestModel = PetCareAndAdoption.Models.RequestPost.UserRequestModel;

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
            CreateMap<PetCareAndAdoption.Models.Posts.ImageModel, ImagePost>().ReverseMap();
            CreateMap<ImagePostModel, ImagePost>()
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.image));

            CreateMap<PetInfoModel, MyPets>().ReverseMap();
            CreateMap<PetCareAndAdoption.Models.Pets.ImageModel, PetImages>().ReverseMap();
            CreateMap<ImagePetModel, PetImages>()
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.image));

            CreateMap<HistoryVaccineTableModel, HistoryVaccine>().ReverseMap();
            CreateMap<HistoryVaccineModel, HistoryVaccine>()
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.note, opt => opt.MapFrom(src => src.note));

            CreateMap<NextVaccineTableModel, NextVaccine>().ReverseMap();
            CreateMap<NextVaccineModel, NextVaccine>()
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.note, opt => opt.MapFrom(src => src.note));

            CreateMap <UserRequestModel, UserRequest>().ReverseMap();
            CreateMap<UserModel, UserRequest>()
                .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.userID));
            CreateMap<FavoritePostModel, FavoritePost>().ReverseMap();
            CreateMap<AddFavoriteModel, FavoritePost>()
                .ForMember(dest => dest.postID, opt => opt.MapFrom(src => src.postID))
                .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.userID));
        }
    }
}
