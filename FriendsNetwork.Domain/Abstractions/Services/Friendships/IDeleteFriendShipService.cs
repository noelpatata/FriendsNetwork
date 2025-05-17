using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;
namespace FriendsNetwork.Domain.Abstractions.Services.Friendships
{
    public interface IDeleteFriendshipService
    {
        Task<bool> DeleteFriendShipServiceAsync(long? userId, Guid? friendOnlineId);

    }
}
