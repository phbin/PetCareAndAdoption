using System.ComponentModel.DataAnnotations;

namespace PetCareAndAdoption.Models
{
    public class UserInfoModel
    {
        [MaxLength(10)]
        public string userID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public string password { get; set; }
    }
}
