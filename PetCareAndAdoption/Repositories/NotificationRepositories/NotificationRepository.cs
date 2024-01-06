using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Migrations;
using PetCareAndAdoption.Models.FavoritePost;
using PetCareAndAdoption.Models.Notification;
using PetCareAndAdoption.Models.Posts;
using System.Diagnostics.CodeAnalysis;
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
                    receiverID =  receiverNameTask,
                    isRead = noti.isRead,
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
            var user = await _context.UserToken!.FirstOrDefaultAsync(u => u.userID == userID && u.token == token);

            if (user == null)
            {
                var newToken = new UserToken
                {
                    tokenID = Guid.NewGuid().ToString(),
                    userID = userID,
                    token = token
                };
                _context.UserToken!.Add(newToken);
                await _context.SaveChangesAsync();
                return "Success";

            }
            return "Success";
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
                    receiverID = receiverID,
                    isRead = false
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

        public async Task<string[]> GetUserToken(string userID)
        {
            var token = await _context.UserToken!
                                .Where(img => img.userID == userID)
                                .ToListAsync();
            var tokens = token.Select(img => img.token).ToArray();
            return tokens;
        }

        public async Task<string> ReadNoti(string notiID)
        {
            var noti = await _context.Notifications!.SingleOrDefaultAsync(u => u.notiID == notiID);
            if (noti != null)
            {
                noti.isRead=true;
                await _context.SaveChangesAsync();
                return "Update successfully";
            }
            else
            {
                return "Notification not found";
            }
        }
    }
}
