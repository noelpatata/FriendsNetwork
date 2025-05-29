using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository;

public class NotificationRepository(FriendsNetworkDbContext context) : INotificationRepository
{
    public async Task<bool> SaveNotification(long fromUserId, long toUserId, string message)
    {
        try
        {
            var notification = new Domain.Entities.Notification
            {
                fromUserId = fromUserId,
                toUserId = toUserId,
                message = message
            };
            await context.Notifications.AddAsync(notification);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw e;
        }
        
    }

    public async Task<IEnumerable<Notification>> GetNonDeliveredNotifications(long userId)
    {
        return await context.Notifications.Where(x => x.toUserId == userId && !x.delivered).ToListAsync();
    }

    public async Task<bool> MarkNotificationAsDelivered(long notificationId)
    {
        var notification = await context.Notifications.Where(x => x.id == notificationId).FirstOrDefaultAsync();
        if (notification == null)
            return false;
        
        notification.delivered = true;
        await context.SaveChangesAsync();
        
        return true;
    }
}