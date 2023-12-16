using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using System.Configuration;

namespace PetCareAndAdoption.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public UserInfoRepository(MyDbContext context, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _context = context;
            _mapper=mapper;
        }
        //public async Task<string> AddUserAsync(UserInfoModel model)
        //{
        //    var newUser = _mapper.Map<UserInfo>(model);
        //    _context.Users!.Add(newUser);
        //    await _context.SaveChangesAsync();
        //    return newUser.userID;
        //}

        public async Task<IdentityResult> DeleteUserAsync(string userID)
        {
            var user = await userManager.FindByNameAsync(userID);

            if (user == null)
            {
                // Người dùng không tồn tại
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                var deleteUser = _context.Users!.SingleOrDefault(b => b.userID == userID);
                if (deleteUser != null)
                {
                    _context.Users!.Remove(deleteUser);
                    await _context.SaveChangesAsync();
                }
                // Xóa thành công
                return IdentityResult.Success;
            }
            else
            {
                // Xóa thất bại, trả về thông báo lỗi
                return result;
            }
        }

        public async Task<List<UserInfoModel>> GetAllUsersAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserInfoModel>>(users);
        }

        public async Task<string> GetAvatarByUserIdAsync(string userID)
        {
            var user = await _context.Users!.FindAsync(userID);

            if (user == null)
            {
                return null; 
            }

            return user.avatar;
        }

        public async Task<UserInfoModel> GetUserByUserIdAsync(string userID)
        {
            var users = await _context.Users!.FindAsync(userID);
            return _mapper.Map<UserInfoModel>(users);
        }

        public async Task UpdateUserAsync(string userID, UpdateUserModel model)
        {
            if (userID == model.userID)
            {
                // Lấy thông tin người dùng từ cơ sở dữ liệu
                var existingUser = await _context.Users
                                          .FirstOrDefaultAsync(u => u.userID == userID);

                if (existingUser != null)
                {
                    model.password = existingUser.password;

                    _mapper.Map(model, existingUser);

                    _context.Users.Update(existingUser);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
