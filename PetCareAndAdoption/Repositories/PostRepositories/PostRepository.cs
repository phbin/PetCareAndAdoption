using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Repositories.PostRepositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration configuration;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(MyDbContext context, IMapper mapper,
            IConfiguration configuration, IMemoryCache memoryCache)
        {
            this.configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddPostAsync(PostModel model, List<ImagePostModel> img)
        {
            if (model != null)
            {
                // Mã OTP đúng, tiếp tục với quá trình đăng ký
                var newPost = new PostAdoptModel
                {
                    postID = Guid.NewGuid().ToString(),
                    petName = model.petName,
                    sex = model.sex,
                    species = model.species,
                    breed = model.breed,
                    weight = model.weight,
                    district = model.district,
                    province = model.province,
                    description = model.description,
                    isVaccinated = model.isVaccinated,
                    isAdopt = model.isAdopt,
                    userID = model.userID,
                };

                var postImages = new List<ImageModel>();

                foreach (var i in img)
                {
                    var newImage = new ImageModel
                    {
                        imgPostID = Guid.NewGuid().ToString(),
                        postID=newPost.postID,
                        image=i.image,
                    };
                    postImages.Add(newImage);

                }
                var post = _mapper.Map<PetPosts>(newPost);
                _context.PetPosts!.Add(post);
                await _context.SaveChangesAsync();

                foreach (var image in postImages)
                {
                    var imgPost = _mapper.Map<ImagePost>(image);
                    _context.ImagePost!.Add(imgPost);
                    await _context.SaveChangesAsync();

                }

                return post.postID;
            }
            else
            {
                return "Invalid ";
            }
        }

        public async Task<string> DeletePostAsync(string postID)
        {
            var delPost = _context.PetPosts!.SingleOrDefault(b => b.postID == postID);
            if (delPost != null)
            {
                _context.PetPosts!.Remove(delPost);
                await _context.SaveChangesAsync();
                return "Success";
            }
            return "Remove post failed!";
        }

        public async Task<List<PostAdoptModel>> GetAllPostsAsync()
        {
            var posts = await _context.PetPosts!.ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }

        public async Task<string[]> GetImagesByPostID(string postID)
        {
            var posts = await _context.ImagePost
                          .Where(p => p.postID == postID)
                          .ToListAsync();
            if (posts != null && posts.Any())
            {
                var imageUrls = posts.Select(p => p.image).ToArray();
                return imageUrls;
            }

            return null; 
        }

        public async Task<List<PostAdoptModel>> GetPostsBySpeciesAsync(string speciesName)
        {
            var posts = await _context.PetPosts
               .Where(p => p.species == speciesName)
               .ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }
        public async Task<List<PostAdoptModel>> GetPostsByIDAsync(string postID)
        {
            var posts = await _context.PetPosts
               .Where(p => p.postID == postID)
               .ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }
        public async Task UpdatePostAsync(string postID, PostAdoptModel model)
        {
            if (postID == model.postID)
            {
                var updatePost = _mapper.Map<PetPosts>(model);
                _context.PetPosts!.Update(updatePost);
                await _context.SaveChangesAsync();

            }
        }
    }
}