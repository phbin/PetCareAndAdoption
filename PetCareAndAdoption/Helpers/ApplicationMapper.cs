using AutoMapper;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using System.Diagnostics.Eventing.Reader;

namespace PetCareAndAdoption.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserInfo, UserInfoModel>().ReverseMap();
        }
    }
}
