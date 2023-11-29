using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Repositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserInfoRepository _userRepo;

        public UsersController(IUserInfoRepository repo)
        {
            _userRepo = repo;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepo.GetAllUsersAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Users/5
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserInfoByID(string userID)
        {
            var user = await _userRepo.GetUserByUserIdAsync(userID);
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userID}")]
        public async Task<IActionResult> UpdateUser(string userID, UserInfoModel model)
        {
            if (userID != model.userID)
            {
                return NotFound();
            }
            await _userRepo.UpdateUserAsync(userID, model);
            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddNewUsers(UserInfoModel model)
        {
            try
            {
                var newUserID = await _userRepo.AddUserAsync(model);
                var user = await _userRepo.GetUserByUserIdAsync(newUserID);
                return user == null ? NotFound() : Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteUserInfo(string userID)
        {
           await _userRepo.DeleteUserAsync(userID);
            return Ok();
        }
    }
}
