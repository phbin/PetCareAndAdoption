using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.FavoriteRepositories
{
    public interface IFavoriteRepository
    {
        public Task<string> AddFavoriteAsync(string userID, string postID);
        public Task<string> RemoveFavoriteAsync(string userID, string favID);
        public Task<List<GetFavoritePostModel>> GetAllFavoritePostAsync(string userID);
    }
}
