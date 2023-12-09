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
        public async Task<string> AddPostAsync(PostModel model)
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
                    latLocation = model.latLocation,
                    destLocation = model.destLocation,
                    nameLocation = model.nameLocation,
                    isVaccinated = model.isVaccinated,
                    isAdopt = model.isAdopt,
                    targetFee = model.targetFee,
                    userID = model.userID,
                };
                var post = _mapper.Map<Posts>(newPost);
                _context.Posts!.Add(post);
                await _context.SaveChangesAsync();

                return post.postID;
            }
            else
            {
                return "Invalid ";
            }
        }

        public async Task<string> DeletePostAsync(string postID)
        {
            var delPost = _context.Posts!.SingleOrDefault(b => b.postID == postID);
            if (delPost != null)
            {
                _context.Posts!.Remove(delPost);
                await _context.SaveChangesAsync();
                return "Success";
            }
            return "Remove post failed!";
        }

        public async Task<List<PostAdoptModel>> GetAllPostsAsync()
        {
            var posts = await _context.Posts!.ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }

        public async Task<List<PostAdoptModel>> GetPostsBySpeciesAsync(string speciesName)
        {
            var posts = await _context.Posts
               .Where(p => p.species == speciesName)
               .ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }

        public async Task UpdatePostAsync(string postID, PostAdoptModel model)
        {
            if (postID == model.postID)
            {
                var updatePost = _mapper.Map<Posts>(model);
                _context.Posts!.Update(updatePost);
                await _context.SaveChangesAsync();

            }
        }
    }
}