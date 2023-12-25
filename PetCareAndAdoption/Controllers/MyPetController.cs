using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Models.Pets;
using PetCareAndAdoption.Repositories.MyPetRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPetController : ControllerBase
    {
        private readonly IPetRepository petRepo;
        public MyPetController(IPetRepository repo)
        {
            petRepo = repo;
        }

        [HttpPost("AddPet")]
        public async Task<IActionResult> AddPet([FromBody] PetWithImageModel model)
        {
            try
            {
                var result = await petRepo.AddPetAsync(model.PetModel, model.Images, model.History, model.Next);

                if (result == "Invalid")
                {
                    return BadRequest("Invalid model");
                }
                else
                {
                    return Ok(new { petID = result });
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

  

        [HttpDelete("RemovePet/{userID}/{petID}")]
        public async Task<IActionResult> DeletePost(string userID, string petID)
        {
            try
            {
                if (string.IsNullOrEmpty(petID))
                {
                    return BadRequest("Invalid postID");
                }

                var result = await petRepo.DeletePetAsync(userID, petID);

                if (result == "Success")
                {
                    return Ok("Pet deleted successfully");
                }
                else
                {
                    return NotFound(result); // "Remove post failed!" or any other error message
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPet()
        {
            try
            {
                return Ok(await petRepo.GetAllPetAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        //[HttpPost("UpdatePet/{petID}")]
        //public async Task<IActionResult> UpdatePet(string petID, PetModel model, List<ImagePetModel> img, List<HistoryVaccineModel> his, List<NextVaccineModel> next)
        //{
        //    try
        //    {
        //        var result = await petRepo.UpdatePetAsync(petID, model, img, his, next);

        //        if (result == "Invalid model")
        //        {
        //            return BadRequest("Invalid model");
        //        }
        //        else if (result == "Pet not found")
        //        {
        //            return NotFound("Pet not found");
        //        }
        //        else
        //        {
        //            return Ok(new { petID = result });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception for debugging purposes
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
