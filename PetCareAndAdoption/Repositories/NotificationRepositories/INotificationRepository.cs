using PetCareAndAdoption.Models.Notification;
using PetCareAndAdoption.Models.Pets;

namespace PetCareAndAdoption.Repositories.NotificationRepositories
{
    public interface INotificationRepository
    {
        public Task<List<NotificationModel>> GetNotiByUser(string userID);
        public Task<string> SaveTokenToUser(string userID, string token);
        public Task<NotificationModel> UpdateNotification(string title, string content, string senderID, string receiverID);
    }
}
