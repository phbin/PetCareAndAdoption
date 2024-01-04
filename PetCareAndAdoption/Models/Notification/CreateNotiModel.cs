namespace PetCareAndAdoption.Models.Notification
{
    public class CreateNotiModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public string senderID { get; set; }
        public string receiverID { get; set; }
    }
}
