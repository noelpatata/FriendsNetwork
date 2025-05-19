using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;

namespace FriendsNetwork.Infrastructure.Validators.V1.FriendRequests
{
    public class AcceptFriendRequestValidator : AbstractValidator<AcceptFriendRequestRequest>
    {
        public AcceptFriendRequestValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Request cannot be null.");

            RuleFor(x => x.FriendOnlineId)
                .NotEmpty()
                .WithMessage("Friend's online ID is required.");
        }
    }
}
