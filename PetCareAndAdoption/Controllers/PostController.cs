using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCareAndAdoption.Models.Authentication;
using PetCareAndAdoption.Models.Posts;
using PetCareAndAdoption.Repositories.AuthenticationRepositories;
using PetCareAndAdoption.Repositories.PostRepositories;

namespace PetCareAndAdoption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postRepo;
        public PostController(IPostRepository repo)
        {
            postRepo = repo;
        }
       
        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody]PostModel model)
        {
            try
            {
                var result = await postRepo.AddPostAsync(model);

                if (result == "Invalid")
                {
                    return BadRequest("Invalid model");
                }
                else
                {
                    return Ok(new { PostID = result });
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{postID}")]
        public async Task<IActionResult> UpdatePost(string postID, PostAdoptModel model)
        {
            if (postID != model.postID)
            {
                return NotFound();
            }
            await postRepo.UpdatePostAsync(postID, model);
            return Ok();
        }

        [HttpDelete("{postID}")]
        public async Task<IActionResult> DeletePost(string postID)
        {
            try
            {
                if (string.IsNullOrEmpty(postID))
                {
                    return BadRequest("Invalid postID");
                }

                var result = await postRepo.DeletePostAsync(postID);

                if (result == "Success")
                {
                    return Ok("Post deleted successfully");
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
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                return Ok(await postRepo.GetAllPostsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{speciesName}")]
        public async Task<IActionResult> GetPostsBySpecies(string speciesName)
        {
            var user = await postRepo.GetPostsBySpeciesAsync(speciesName);
            return user == null ? NotFound() : Ok(user);
        }
    }
}
