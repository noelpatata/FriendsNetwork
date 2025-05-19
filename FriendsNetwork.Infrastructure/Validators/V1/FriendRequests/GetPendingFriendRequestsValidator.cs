using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;

namespace FriendsNetwork.Infrastructure.Validators.V1.FriendRequests
{
    public class GetPendingFriendRequestsValidator : AbstractValidator<GetPendingFriendRequestsRequest>
    {
        public GetPendingFriendRequestsValidator()
        {
        }
    }
}
