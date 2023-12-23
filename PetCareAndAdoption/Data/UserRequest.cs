using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("UserRequest")]
    public class UserRequest
    {
        [Key]
        public string requestID { get; set; }
        public string postID { get; set; }
        public string userID { get; set; }
    }
}
