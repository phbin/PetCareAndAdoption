using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserInfoByID(string userID)
        {
            var user = await _userRepo.GetUserByUserIdAsync(userID);
            return user == null ? NotFound() : Ok(user);
        }

        //[HttpPut("{userID}")]
        //public async Task<IActionResult> UpdateUser(string userID, UserInfoModel model)
        //{
        //    if (userID != model.userID)
        //    {
        //        return NotFound();
        //    }
        //    await _userRepo.UpdateUserAsync(userID, model);
        //    return Ok();
        //}

        //// POST: api/Users
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> AddNewUsers(UserInfoModel model)
        //{
        //    try
        //    {
        //        var newUserID = await _userRepo.AddUserAsync(model);
        //        var user = await _userRepo.GetUserByUserIdAsync(newUserID);
        //        return user == null ? NotFound() : Ok(user);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteUserInfo(string userID)
        {
            var result =  await _userRepo.DeleteUserAsync(userID);
            if (result.Succeeded)
            {
                return Ok();

            }
            else return BadRequest();   
        }
    }
}
