using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("UserToken")]
    public class UserToken
    {
        [Key]
        public string tokenID { get; set; }
        public string userID { get; set; }
        public string token { get; set; }
    }
}
