using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Models.Pets;
using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Repositories.FavoriteRepositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddFavoriteAsync(string userID, string postID)
        {
            try
            {
                var existingFavorite = await _context.FavoritePost!
           .FirstOrDefaultAsync(fp => fp.userID == userID && fp.postID == postID);

                if (existingFavorite != null)
                {
                    return "This favorite post already add for this user.";
                }
                var favorite = new FavoritePost
                {
                    FavId = Guid.NewGuid().ToString(),
                    userID = userID,
                    postID = postID
                };

                _context.FavoritePost!.Add(favorite);
                await _context.SaveChangesAsync();

                return favorite.FavId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<GetFavoritePostModel>> GetAllFavoritePostAsync(string userID)
        {
            try
            {
                var favorites = await _context.FavoritePost!
                    .Where(fp => fp.userID == userID)
                    .ToListAsync();

                var result = new List<GetFavoritePostModel>();
                foreach (var favorite in favorites)
                {
                    var post = await _context.PetPosts!
                        .FirstOrDefaultAsync(p => p.postID == favorite.postID);

                    if (post != null)
                    {
                        var imageEntities = await _context.ImagePost!
                            .Where(img => img.postID == post.postID)
                            .ToListAsync();
                        var imageUrls = imageEntities.Select(img => img.image).ToArray();

                        var postModel = _mapper.Map<PostAdoptModel>(post);


                        result.Add(new GetFavoritePostModel
                        {
                            postAdoptModel = postModel,
                            Images = imageUrls,
                            favID = favorite.FavId
                        });
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<string> RemoveFavoriteAsync(string userID, string postID)
        {
            try
            {
                var favorite = await _context.FavoritePost!
                    .FirstOrDefaultAsync(fp => fp.postID == postID && fp.userID == userID);

                if (favorite != null)
                {
                    _context.FavoritePost!.Remove(favorite);
                    await _context.SaveChangesAsync();

                    return "Success";
                }

                return "Favorite not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
