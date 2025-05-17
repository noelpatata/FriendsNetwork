using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Users;

namespace FriendsNetwork.Application.Handlers.Users
{
    public class CreateUserHandler(ICreateUserService userGetService, IMapper mapper) : IHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ICreateUserService _userGetService = userGetService ?? throw new ArgumentNullException(nameof(userGetService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request)
        {
            //craeting
            var user = await _userGetService.CreateUserServiceAsync(request.username, request.password);
            
            //mapping
            var mappedUser = _mapper.Map<UserViewModel?>(user);

            return new CreateUserResponse
            {
                userViewModel = mappedUser
            };

        }
    }
}
