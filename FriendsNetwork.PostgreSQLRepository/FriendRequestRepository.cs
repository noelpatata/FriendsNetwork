using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsNetwork.PosgreSqlRepository
{
    public class FriendRequestRepository(FriendsNetworkDbContext context) : IFriendRequestRepository
    {
        private readonly FriendsNetworkDbContext _dbContext = context;
        public async Task<bool> AcceptFriendRequest(FriendRequest fr)
        {
            //check as accepted
            fr.accepted = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DenyFriendRequest(FriendRequest fr)
        {
            _dbContext.FriendRequests.Remove(fr);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FriendRequest>> GetPendingFriendRequests(long userId)
        {
            return await _dbContext.FriendRequests
                .Where(x => x.receiver_id == userId && !x.accepted)
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .ToListAsync();
        }


        public async Task<FriendRequest> SendFriendRequest(long userId, long friendUserId, User friendUser)
        {
            var newFriendRequest = new FriendRequest
            {
                sender_id = userId,
                receiver_id = friendUserId,
                Receiver = friendUser

            };

            _dbContext.FriendRequests.Add(newFriendRequest);
            await _dbContext.SaveChangesAsync();

            return newFriendRequest;
        }
        public async Task<bool> DeleteFriendRequests(long userA, long userB)
        {
            var requests = await _dbContext.FriendRequests
                .Where(fr =>
                    (fr.sender_id == userA && fr.receiver_id == userB) ||
                    (fr.sender_id == userB && fr.receiver_id == userA))
                .ToListAsync();

            _dbContext.FriendRequests.RemoveRange(requests);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<FriendRequest?> GetReceivedFriendRequestFromUser(long user1Id, long user2Id)
        {
            return await _dbContext.FriendRequests
                .Where(x => x.receiver_id == user1Id && x.sender_id == user2Id)
                .OrderByDescending(x => x.id)
                .Include(x=>x.Sender)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> PreviousFriendRequestsSent(long user1, long user2)
        {
            var existingRequest = await _dbContext.FriendRequests
                   .FirstOrDefaultAsync(x => x.sender_id == user1 && x.receiver_id == user2);

            return existingRequest != null;
        }
    }
    


        
}
