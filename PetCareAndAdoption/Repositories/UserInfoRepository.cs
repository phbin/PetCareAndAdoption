using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;

namespace PetCareAndAdoption.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public UserInfoRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        public async Task<string> AddUserAsync(UserInfoModel model)
        {
            var newUser = _mapper.Map<UserInfo>(model);
            _context.Users!.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.userID;
        }

        public async Task DeleteUserAsync(string userID)
        {
            var deleteUser = _context.Users!.SingleOrDefault(b => b.userID == userID);
            if(deleteUser != null)
            {
                 _context.Users!.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserInfoModel>> GetAllUsersAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserInfoModel>>(users);
        }

        public async Task<UserInfoModel> GetUserByUserIdAsync(string userID)
        {
            var users = await _context.Users!.FindAsync(userID);
            return _mapper.Map<UserInfoModel>(users);
        }

        public async Task UpdateUserAsync(string userID, UserInfoModel model)
        {
            if (userID == model.userID)
            {
                var updateUser = _mapper.Map<UserInfo>(model);
                _context.Users!.Update(updateUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
