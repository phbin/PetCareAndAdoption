namespace PetCareAndAdoption.Models.Posts
{
    public class PostFullUpdateModel
    {
        public PostUpdateModel PostModel { get; set; }
        public List<ImagePostModel> Images { get; set; }
    }
}
