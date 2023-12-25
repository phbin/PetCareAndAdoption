namespace PetCareAndAdoption.Models.Posts
{
    public class PostIDWithRequestModel
    {
        public PostAdoptModel postID { get; set; }
        public List<UserRequestModel> request { get; set; }
        public string[] Images { get; set; }
    }
}
