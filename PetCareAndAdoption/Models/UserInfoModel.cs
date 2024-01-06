using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models
{
    public class UserInfoModel
    {
        [MaxLength(10)]
        public string userID { get; set; }
        public string name { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }
    }
}
