using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;

namespace FriendsNetwork.Infrastructure.Validators.V1.Friendships
{
    public class DeleteFriendshipValidator: AbstractValidator<DeleteFriendshipRequest>
    {
        public DeleteFriendshipValidator()
        {
            RuleFor(x => x.userId)
                .NotEmpty()
                .WithMessage("UserId is required.");
            RuleFor(x => x.friendOnlineId)
                .NotEmpty()
                .WithMessage("FriendId is required.");
        }
    }
}
