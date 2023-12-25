using PetCareAndAdoption.Models.Posts;

namespace PetCareAndAdoption.Models.FavoritePost
{
    public class GetFavoritePostModel
    {
        public PostAdoptModel post { get; set; }
        public string favID { get; set; }
        public string[] Images { get; set; }
    }
}
