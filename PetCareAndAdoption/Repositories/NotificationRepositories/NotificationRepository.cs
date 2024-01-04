using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Migrations;
using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Models.Notification;
using PetCareAndAdoption.Models.Posts;
using Notifications = PetCareAndAdoption.Data.Notifications;

namespace PetCareAndAdoption.Repositories.NotificationRepositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public NotificationRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<NotificationModel>> GetNotiByUser(string userID)
        {
            var notifications = await _context.Notifications!
                .Where(noti => noti.receiverID == userID)
                .ToListAsync();

            var result = new List<NotificationModel>();

            foreach (var noti in notifications)
            {
                var senderNameTask = await GetUserNameAsync(noti.senderID);
                var receiverNameTask = await GetUserNameAsync(noti.receiverID);

                var notificationModel = new NotificationModel
                {
                    notiID = noti.notiID,
                    title = noti.title,
                    content = noti.content,
                    senderID =  senderNameTask,
                    receiverID =  receiverNameTask
                };

                result.Add(notificationModel);
            }

            return result;
        }
        private async Task<string> GetUserNameAsync(string userID)
        {
            var user = await _context.Users!.SingleOrDefaultAsync(u => u.userID == userID);
            return user?.name ?? "Unknown User";
        }
        public async Task<string> SaveTokenToUser(string userID, string token)
        {
            var user = await _context.Users!.SingleOrDefaultAsync(u => u.userID == userID);

            if (user != null)
            {
                if (user.token == token)
                {
                    return "Token already exists";
                }

                user.token = token;
                await _context.SaveChangesAsync();

                return "Token updated successfully";
            }

            return "User not found";
        }

        public async Task<NotificationModel> UpdateNotification(string title, string content, string senderID, string receiverID)
        {
            try
            {
                var newNotiID = Guid.NewGuid().ToString();

                while (await _context.Notifications!.AnyAsync(n => n.notiID == newNotiID))
                {
                    newNotiID = Guid.NewGuid().ToString();
                }

                var newNotification = new Notifications
                {
                    notiID = newNotiID,
                    title = title,
                    content = content,
                    senderID = senderID,
                    receiverID = receiverID
                };

                _context.Notifications!.Add(newNotification);
                await _context.SaveChangesAsync();

                var newNotificationModel = _mapper.Map<NotificationModel>(newNotification);

                return newNotificationModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
