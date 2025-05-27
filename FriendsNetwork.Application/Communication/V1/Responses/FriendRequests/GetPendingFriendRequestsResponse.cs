using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Application.Communication.V1.Responses.FriendRequests
{
    public class GetPendingFriendRequestsResponse: GenericResponse<IEnumerable<FriendRequestViewModel?>>
    {
    }
}
