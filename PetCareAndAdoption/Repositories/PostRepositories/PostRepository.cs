using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Repositories.PostRepositories
{
    public class PostRepository : IPostRepository
    {
        public Task<string> AddPostAsync(PostAdoptModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeletePostAsync(string postID)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostAdoptModel>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostAdoptModel> GetPostBySpeciesAsync(string speciesID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePostAsync(string postID, PostAdoptModel model)
        {
            throw new NotImplementedException();
        }
    }
}