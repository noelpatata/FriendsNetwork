using FriendsNetwork.Application.Services.FriendRequests.Exceptions;
using FriendsNetwork.Application.Services.Users.Exceptions;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests.Exceptions;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.SqlRepository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendRequestRepository(FriendsNetworkDbContext context) : IFriendRequestRepository
    {
        private readonly FriendsNetworkDbContext _dbContext = context;
        public async Task<FriendRequest> AcceptFriendRequest(long? userId, Guid? friendOnlineId)
        {
            try
            {
                var senderUser = await _dbContext.Users.Where(u => u.online_id == friendOnlineId).FirstOrDefaultAsync();
                if (senderUser == null)
                    throw new UserNotFoundException();

                if (userId == senderUser.id)
                    throw new CannotAcceptYourSelfException();

                var friendRequest = await _dbContext.FriendRequests.Where(x => x.receiver_id == userId && x.sender_id == senderUser.id).OrderByDescending(x => x.id).FirstOrDefaultAsync();

                if (friendRequest == null)
                    throw new FriendRequestsNotFoundException();

                //accept friend request
                friendRequest.accepted = true;

                //add friend relationship (both ways)
                var newFriend1 = new Friendship
                {
                    user_id = userId ?? 0,
                    friend_id = senderUser.id
                };

                var newFriend2 = new Friendship
                {
                    user_id = senderUser.id,
                    friend_id = userId ?? 0
                };
                await _dbContext.Friendships.AddRangeAsync([newFriend1, newFriend2]);

                await _dbContext.SaveChangesAsync();//apply changes

                return friendRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FriendRequest> DenyFriendRequest(long? userId, Guid? friendOnlineId)
        {
            try
            {
                var senderUserId = await _dbContext.Users.Where(u => u.online_id == friendOnlineId).FirstOrDefaultAsync();
                if (senderUserId == null)
                    throw new UserNotFoundException();

                var friendRequest = await _dbContext.FriendRequests.Where(x => x.receiver_id == userId && x.sender_id == senderUserId.id)
                    .Include(x => x.Sender)
                    .Include(x => x.Receiver)
                    .FirstOrDefaultAsync();
                if (friendRequest == null)
                    throw new FriendRequestsNotFoundException();

                _dbContext.FriendRequests.RemoveRange(friendRequest);
                await _dbContext.SaveChangesAsync();

                return friendRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FriendRequest>> GetPendingFriendRequests(long? userId)
        {
            try
            {
                return await _dbContext.FriendRequests
                                    .Where(x => x.receiver_id == userId && !x.accepted)
                                    .Include(x => x.Sender)
                                    .Include(x => x.Receiver)
                                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public async Task<FriendRequest> SendFriendRequest(long? userId, Guid? friendOnlineId)
        {
            try
            {
                if (userId == null || userId <= 0)
                    throw new ArgumentNullException(nameof(userId));

                var targetUser = await _dbContext.Users.Where(u => u.online_id == friendOnlineId)
                    .FirstOrDefaultAsync();

                if (targetUser == null)
                    throw new UserNotFoundException();

                if (userId == targetUser.id)
                    throw new CannotAddYourSelfException();

                var existingRequest = await _dbContext.FriendRequests
                    .FirstOrDefaultAsync(x => x.sender_id == userId && x.receiver_id == targetUser.id);
                    

                var newFriendRequest = new FriendRequest
                {
                    sender_id = userId ?? 0,
                    receiver_id = targetUser.id,
                    Receiver = targetUser

                };

                _dbContext.FriendRequests.Add(newFriendRequest);
                await _dbContext.SaveChangesAsync();

                return newFriendRequest;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
