using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;

namespace PetCareAndAdoption.Repositories
{
    public interface IUserInfoRepository
    {
        public Task<List<UserInfoModel>> GetAllUsersAsync();
        public Task<UserInfoModel> GetUserByUserIdAsync(string userID);
        public Task<string> GetAvatarByUserIdAsync(string userID);
        //public Task<string> AddUserAsync(UserInfoModel model);
        public Task UpdateUserAsync(string userID, UpdateUserModel model);
        public Task<IdentityResult> DeleteUserAsync(string userID);
    }
}
