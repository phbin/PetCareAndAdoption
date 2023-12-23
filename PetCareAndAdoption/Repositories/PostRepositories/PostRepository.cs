using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Models;
using PetCareAndAdoption.Models.Posts;
using System.Collections.Concurrent;

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
                var newPost = new PostAdoptModel
                {
                    postID = Guid.NewGuid().ToString(),
                    petName = model.petName,
                    sex = model.sex,
                    species = model.species,
                    breed = model.breed,
                    age = model.age,
                    weight = model.weight,
                    district = model.district,
                    province = model.province,
                    description = model.description,
                    isVaccinated = model.isVaccinated,
                    isAdopt = model.isAdopt,
                    userID = model.userID,
                    receiverID = "",
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

        public async Task<List<GetAllPostModel>> GetAllPostsAsync()
        {
            var posts = await _context.PetPosts!
                .Where(post => !post.isDone)
                .ToListAsync();
            var result = new List<GetAllPostModel>();
            foreach (var post in posts)
            {
                var imageEntities = await _context.ImagePost!
                    .Where(img => img.postID == post.postID)
                    .ToListAsync();
                var imageUrls = imageEntities.Select(img => img.image).ToArray();

                var request = await _context.UserRequest!
                   .Where(img => img.postID == post.postID)
                   .ToListAsync();
                var requestUser = request.Select(img => img.userID).ToArray();

                var postModel = _mapper.Map<PostAdoptModel>(post);

                result.Add(new GetAllPostModel
                {
                    PostAdoptModel = postModel,
                    Images = imageUrls,
                    request=requestUser
                });
            }
            return result;
        }


        public async Task<string[]> GetImagesByPostID(string postID)
        {
            var posts = await _context.ImagePost!
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
            var posts = await _context.PetPosts!
               .Where(p => p.species == speciesName)
               .ToListAsync();
            return _mapper.Map<List<PostAdoptModel>>(posts);
        }
        public async Task<PostAdoptModel> GetPostsByIDAsync(string postID)
        {
            var posts = await _context.PetPosts!
               .Where(p => p.postID == postID)
               .FirstOrDefaultAsync();
            return _mapper.Map<PostAdoptModel>(posts);
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

        public async Task RequestAdoption(string postID, string userID)
        {
            var request = new UserRequest
            {
                 requestID= Guid.NewGuid().ToString(),
                postID = postID,
                userID = userID
            };

            _context.UserRequest!.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AllRequestPostModel>> GetAllRequestPostAsync(string userID)
        {
            var postIDs = await _context.UserRequest!
                .Where(request => request.userID == userID)
                .Select(request => request.postID)
                .ToListAsync();

            var posts = await _context.PetPosts!
                .Where(post => postIDs.Contains(post.postID))
                .ToListAsync();

            var result = new List<AllRequestPostModel>();

            foreach (var post in posts)
            {
                var imageEntities = await _context.ImagePost!
                    .Where(img => img.postID == post.postID)
                    .ToListAsync();
                var imageUrls = imageEntities.Select(img => img.image).ToArray();

                var postModel = _mapper.Map<PostAdoptModel>(post);

                result.Add(new AllRequestPostModel
                {
                    PostAdoptModel = postModel,
                    Images = imageUrls
                });
            }

            return result;
        }

        public async Task<List<GetAllPostModel>> GetAllPostsAsync(string userID)
        {
            var posts = await _context.PetPosts!
                .Where(post => !post.isDone)
                .ToListAsync();
            var result = new List<GetAllPostModel>();

            foreach (var post in posts)
            {
                var isPostInUserRequest = await _context.UserRequest!
                    .AnyAsync(ur => ur.postID == post.postID && ur.userID == userID);

                if (isPostInUserRequest)
                {
                    continue;
                }

                var imageEntities = await _context.ImagePost!
                    .Where(img => img.postID == post.postID)
                    .ToListAsync();
                var imageUrls = imageEntities.Select(img => img.image).ToArray();

                var request = await _context.UserRequest!
                   .Where(img => img.postID == post.postID)
                   .ToListAsync();
                var requestUser = request.Select(img => img.userID).ToArray();

                var postModel = _mapper.Map<PostAdoptModel>(post);

                result.Add(new GetAllPostModel
                {
                    PostAdoptModel = postModel,
                    Images = imageUrls,
                    request = requestUser
                });
            }

            return result;
        }

        public async Task<string> AcceptUserAsync(string postID, string receiverID)
        {
            try
            {
                var userRequests = await _context.UserRequest!
                    .Where(ur => ur.postID == postID)
                    .ToListAsync();

                if (userRequests.Any())
                {
                    _context.UserRequest!.RemoveRange(userRequests);

                    var petPost = await _context.PetPosts!
                        .SingleOrDefaultAsync(post => post.postID == postID);

                    if (petPost != null)
                    {
                        petPost.isDone = true;
                        petPost.receiverID = receiverID;

                        await _context.SaveChangesAsync();

                        return "Success";
                    }
                    else
                    {
                        return "PetPost not found!";
                    }
                }
                else
                {
                    return "No matching UserRequest records found.";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred while processing the request.";
            }
        }


        public async Task<string> RejectPostAsync(string postID, string userID)
        {
            var userRequest = await _context.UserRequest!
                .SingleOrDefaultAsync(ur => ur.postID == postID && ur.userID == userID);

            if (userRequest != null)
            {
                _context.UserRequest!.Remove(userRequest);
                await _context.SaveChangesAsync();
                return "Success";
            }

            return "Remove post failed!";
        }

        public async Task<List<AllRequestPostModel>> GetAllReceivedPostAsync(string userID)
        {
            var posts = await _context.PetPosts!
                .Where(post => post.isDone && post.receiverID == userID)
                .ToListAsync();

            var result = new List<AllRequestPostModel>();

            foreach (var post in posts)
            {
                var imageEntities = await _context.ImagePost!
                    .Where(img => img.postID == post.postID)
                    .ToListAsync();
                var imageUrls = imageEntities.Select(img => img.image).ToArray();

                var postModel = _mapper.Map<PostAdoptModel>(post);

                result.Add(new AllRequestPostModel
                {
                    PostAdoptModel = postModel,
                    Images = imageUrls
                });
            }

            return result;
        }

        public async Task<List<PostIDWithRequestModel>> GetPostsWithRequestAsync(string userID)
        {
            var postIDs = await GetPostIDsByUserAsync(userID);

            var posts = await _context.PetPosts!
                .Where(post => postIDs.Contains(post.postID) && !post.isDone && post.userID == userID)
                .ToListAsync();

            var result = new List<PostIDWithRequestModel>();

            foreach (var post in posts)
            {
                var request = await _context.UserRequest!
                    .Where(ur => ur.postID == post.postID)
                    .ToListAsync();

                var requestUser = request != null ? request.Select(ur => ur.userID).ToArray() : null;

                result.Add(new PostIDWithRequestModel
                {
                    postID = post.postID,
                    request=requestUser
                });
            
            }

            return result;
        }

        public async Task<List<string>> GetPostIDsByUserAsync(string userID)
        {
            var postIDs = await _context.PetPosts!
                .Where(user => user.userID == userID)
                .Select(request => request.postID)
                .ToListAsync();

            return postIDs;
        }
    }
}