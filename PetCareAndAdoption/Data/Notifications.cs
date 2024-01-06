using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareAndAdoption.Data
{
    [Table("Notifications")]
    public class Notifications
    {
        [Key]
        public string notiID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string senderID { get; set; }
        public string receiverID { get; set; }
        public bool isRead { get; set; }
    }
}
