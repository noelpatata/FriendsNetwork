using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;

namespace FriendsNetwork.Infrastructure.Validators.V1.Users
{
    public class GetByUsernameValidator: AbstractValidator<GetByUsernameRequest>
    {
        public GetByUsernameValidator()
        {
            RuleFor(x => x.username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .NotNull().WithMessage("Username cannot be null.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.");
        }
    }
}
