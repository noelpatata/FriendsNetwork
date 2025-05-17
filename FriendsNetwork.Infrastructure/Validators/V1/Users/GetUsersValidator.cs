using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;

namespace FriendsNetwork.Infrastructure.Validators.V1.Users
{
    public class GetUsersValidator: AbstractValidator<GetUsersRequest>
    {
        public GetUsersValidator()
        {
            
        }
    }
}
