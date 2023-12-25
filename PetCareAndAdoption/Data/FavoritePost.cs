using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("FavoritePost")]
    public class FavoritePost
    {
        [Key]
        public string FavId { get; set; }
        public string postID { get; set; }
        public string userID { get; set; }
    }
}
