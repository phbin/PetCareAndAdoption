using Microsoft.AspNetCore.Identity;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Posts;
using UserInfoModel = PetCareAndAdoption.Models.Posts.UserInfoModel;

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
        public Task RequestAdoption(string postID, string userRequest);
        public Task<List<GetAllPostModel>> GetAllPostsAsync(string userID);
        public Task<List<AllRequestPostModel>> GetAllRequestPostAsync(string userID);
        public Task<List<AllRequestPostModel>> GetAllReceivedPostAsync(string userID);
        public Task<string> AcceptUserAsync(string postID, string receiverID);
        public Task<string> RejectPostAsync(string postID, string userID);
        public Task<List<PostIDWithRequestModel>> GetPostsWithRequestAsync(string userID);
        public Task<List<string>> GetPostIDsByUserAsync(string userID);
        public Task<string> CancelRequest(string postID, string userID);
        public Task<UserInfoModel> GetUser(string userID);
        public Task<List<GetAllPostModel>> GetPostsByUser(string userID);
        public Task<string> UpdatePostAsync (string postID, PostUpdateModel model, List<ImagePostModel> img);
    }
}
