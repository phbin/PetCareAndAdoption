using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;

namespace PetCareAndAdoption.Repositories
{
    public interface IUserInfoRepository
    {
        public Task<List<UserInfoModel>> GetAllUsersAsync();
        public Task<UserInfoModel> GetUserByUserIdAsync(string userID);
        //public Task<string> AddUserAsync(UserInfoModel model);
        //public Task UpdateUserAsync(string userID, UserInfoModel model);
        public Task<IdentityResult> DeleteUserAsync(string userID);
    }
}
