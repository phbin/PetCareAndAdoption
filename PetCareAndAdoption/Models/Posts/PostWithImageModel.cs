namespace PetCareAndAdoption.Models.Posts
{
    public class PostWithImageModel
    {
        public PostModel PostModel { get; set; }
        public List<ImagePostModel> Images { get; set; }
    }
}
