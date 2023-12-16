using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("ImagePost")]
    public class ImagePost
    {
        [Key]
        public string imgPostID { get; set; }
        public string postID { get; set; }
        public string image { get; set; }
    }
}
