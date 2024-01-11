using PetCareAndAdoption.Models.Notification;
using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.NotificationRepositories
{
    public interface INotificationRepository
    {
        public Task<List<NotificationModel>> GetNotiByUser(string userID);
        public Task<string> SaveTokenToUser(string userID, string token);
        public Task<NotificationModel> UpdateNotification(string title, string content, string senderID, string receiverID);
        public Task<string[]> GetUserToken(string userID);
        public Task<string> ReadNoti(string notiID);
        public Task<string> RemoveToken(string userID, string token);

    }
}
