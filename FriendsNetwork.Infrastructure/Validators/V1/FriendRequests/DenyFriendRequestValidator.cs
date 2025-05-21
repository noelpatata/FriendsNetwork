using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;

namespace FriendsNetwork.Infrastructure.Validators.V1.FriendRequests
{
    public class DenyFriendRequestValidator : AbstractValidator<DenyFriendRequestRequest>
    {
        public DenyFriendRequestValidator()
        {

            RuleFor(x => x)
                .NotNull().WithMessage("Request cannot be null.");
            RuleFor(x => x.friendOnlineId)
                .NotEmpty()
                .WithMessage("Friend's online ID is required.");
        }
    }
}
