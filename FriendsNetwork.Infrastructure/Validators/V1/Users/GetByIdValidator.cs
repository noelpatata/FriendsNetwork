using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.UseCases.V1.Users;

namespace FriendsNetwork.Infrastructure.Validators.V1.Users;

public class GetByIdValidator : AbstractValidator<GetByIdRequest>
{
    public GetByIdValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("Request cannot be null.");;
    }
}