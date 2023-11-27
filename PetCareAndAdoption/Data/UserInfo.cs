using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        [MaxLength(10)]
        public int userID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public string password { get; set; }
    }
}
