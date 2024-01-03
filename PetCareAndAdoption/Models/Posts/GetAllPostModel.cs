namespace PetCareAndAdoption.Models.Posts
{
    public class GetAllPostModel
    {
        public PostAdoptModel PostAdoptModel { get; set; }
        public bool isFav { get; set; }
        public string[] Images { get; set; }
        public string[] request { get; set; }
    }
}
