using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;

namespace FriendsNetwork.Infrastructure.Validators.V1.Notifications;

public class GetNonDeliveredValidator : AbstractValidator<GetNonDeliveredRequest>
{
    public GetNonDeliveredValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("Request cannot be null.");
    }
}