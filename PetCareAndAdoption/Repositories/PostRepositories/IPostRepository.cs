using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Repositories.PostRepositories
{
    public interface IPostRepository
    {       
        public Task<string> AddPostAsync(PostModel model, List<ImagePostModel> img);
        public Task UpdatePostAsync(string postID, PostAdoptModel model);
        public Task<string> DeletePostAsync(string postID);
        public Task<List<GetAllPostModel>> GetAllPostsAsync();
        public Task<string[]> GetImagesByPostID(string postID);
        public Task<List<PostAdoptModel>> GetPostsBySpeciesAsync(string speciesName);
        public Task<PostAdoptModel> GetPostsByIDAsync(string postID);
    }
}
