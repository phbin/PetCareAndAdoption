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
        public async Task<IActionResult> AddPost([FromBody]PostWithImageModel model)
        {
            try
            {
                var result = await postRepo.AddPostAsync(model.PostModel, model.Images);

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

        [HttpGet("GetBySpecies{speciesName}")]
        public async Task<IActionResult> GetPostsBySpecies(string speciesName)
        {
            var result = await postRepo.GetPostsBySpeciesAsync(speciesName);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet("GetByID{postID}")]
        public async Task<IActionResult> GetPostsByID(string postID)
        {
            var result = await postRepo.GetPostsByIDAsync(postID);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet("GetImagesByPosts")]
        public async Task<IActionResult> GetImagesByPosts(string postID)
        {
            var result = await postRepo.GetImagesByPostID(postID);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPost("RequestAdoption")]
        public async Task<IActionResult> RequestAdoption(string postID, string userRequest)
        {
            try
            {
                await postRepo.RequestAdoption(postID, userRequest);

                return Ok("Adoption request sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("GetRequestPosts")]
        public async Task<IActionResult> GetPostsByRequestUser([FromQuery] string userID)
        {
            try
            {
                var posts = await postRepo.GetAllRequestPostAsync(userID);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("GetReceivedPosts")]
        public async Task<IActionResult> GetReceivedPosts([FromQuery] string userID)
        {
            try
            {
                var posts = await postRepo.GetAllReceivedPostAsync(userID);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("GetAllPostsWithUser")]
        public async Task<IActionResult> GetAllPostsWithUser([FromQuery] string userID)
        {
            try
            {
                var posts = await postRepo.GetAllPostsAsync(userID);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("RejectUser")]
        public async Task<IActionResult> RejectPost([FromQuery] string postID, [FromQuery] string userID)
        {
            try
            {
                var result = await postRepo.RejectPostAsync(postID, userID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("AcceptUser")]
        public async Task<IActionResult> AcceptUser(string postID, string receiverID)
        {
            try
            {
                var result = await postRepo.AcceptUserAsync(postID, receiverID);

                if (result == "Success")
                {
                    return Ok(new { Message = "User accepted successfully." });
                }
                else
                {
                    return BadRequest(new { Message = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }
        [HttpGet("PostsWithRequest")]
        public async Task<IActionResult> GetPostsWithRequestByUserAsync(string userID)
        {
            try
            {
                var result = await postRepo.GetPostsWithRequestAsync(userID);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
        [HttpPost("CancelRequest")]
        public async Task<IActionResult> CancelRequest([FromQuery] string postID, [FromQuery] string userID)
        {
            try
            {
                var result = await postRepo.CancelRequest(postID, userID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
