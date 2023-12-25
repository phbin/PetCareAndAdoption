namespace PetCareAndAdoption.Models.Posts
{
    public class AllRequestPostModel
    {
        public PostAdoptModel PostAdoptModel { get; set; }
        public UserInfoModel UserInfo { get; set; }
        public string[] Images { get; set; }
    }
}
