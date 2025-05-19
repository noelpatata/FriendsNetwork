using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.FriendRequests
{
    public interface IGetPendingFriendRequestsService
    {
        Task<IEnumerable<FriendRequest>> GetPendingFriendRequestsAsync(long? userId);
    }
}
