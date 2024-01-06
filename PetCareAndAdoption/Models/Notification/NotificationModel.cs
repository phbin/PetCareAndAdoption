namespace PetCareAndAdoption.Models.Notification
{
    public class NotificationModel
    {
        public string notiID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string senderID { get; set; }
        public string receiverID { get; set; }
        public bool isRead { get; set; }
    }
}
