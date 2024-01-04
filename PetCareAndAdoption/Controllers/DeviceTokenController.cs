﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Migrations;
using PetCareAndAdoption.Models.Notification;
using PetCareAndAdoption.Repositories.FavoriteRepositories;
using PetCareAndAdoption.Repositories.NotificationRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTokenController : ControllerBase
    {
        private readonly INotificationRepository _notiRepo;

        public DeviceTokenController(INotificationRepository notiRepo)
        {
            _notiRepo = notiRepo;
        }
        [HttpPost("UpdateToken")]
        public async Task<IActionResult> UpdateToken(string userID, string token )
        {
            try
            {
                var result = await _notiRepo.SaveTokenToUser(userID, token);

                if (result == "Token updated successfully")
                {
                    return Ok("Token updated successfully");
                }
                else if (result == "Token already exists")
                {
                    return BadRequest(result);
                }
                else 
                {
                    return NotFound(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetNotifications/{userID}")]
        public async Task<IActionResult> GetNotifications(string userID)
        {
            try
            {
                var notifications = await _notiRepo.GetNotiByUser(userID);

                return Ok(notifications);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(CreateNotiModel model)
        {
            try
            {
                var result = await _notiRepo.UpdateNotification(model.title, model.content, model.senderID, model.receiverID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
