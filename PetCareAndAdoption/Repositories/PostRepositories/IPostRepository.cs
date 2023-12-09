using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Repositories.PostRepositories
{
    public interface IPostRepository
    {       
        public Task<string> AddPostAsync(PostModel model);
        public Task UpdatePostAsync(string postID, PostAdoptModel model);
        public Task<string> DeletePostAsync(string postID);
        public Task<List<PostAdoptModel>> GetAllPostsAsync();
        public Task<List<PostAdoptModel>> GetPostsBySpeciesAsync(string speciesName);
    }
}
