using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Repositories.FavoriteRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritePostController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepo;

        public FavoritePostController(IFavoriteRepository favoriteRepo)
        {
            _favoriteRepo = favoriteRepo;
        }

        [HttpPost("AddFavorite")]
        public async Task<IActionResult> AddFavorite([FromBody]AddFavoriteModel model)
        {
            try
            {
                var result = await _favoriteRepo.AddFavoriteAsync(model.userID, model.postID);

                switch (result)
                {
                    case "This favorite post already added for this user.":
                        return BadRequest("This favorite post already added for this user.");
                    default:
                        return Ok(new { favID = result });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllFavoritePosts/{userID}")]
        public async Task<IActionResult> GetAllFavoritePosts(string userID)
        {
            try
            {
                var result = await _favoriteRepo.GetAllFavoritePostAsync(userID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("RemoveFavorite/{userID}/{postID}")]
        public async Task<IActionResult> RemoveFavorite(string userID, string postID)
        {
            try
            {
                var result = await _favoriteRepo.RemoveFavoriteAsync(userID, postID);

                if (result == "Success")
                {
                    return Ok("Favorite removed successfully");
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
    }
}
