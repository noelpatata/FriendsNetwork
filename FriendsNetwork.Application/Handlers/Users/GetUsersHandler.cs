using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Users;

namespace FriendsNetwork.Application.Handlers.Users
{
    public class GetUsersHandler(IGetUsersService userGetService, IMapper mapper) : IHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IGetUsersService _userGetService = userGetService ?? throw new ArgumentNullException(nameof(userGetService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<GetUsersResponse?> HandleAsync(GetUsersRequest? request)
        {
            var user = await _userGetService.GetUsersServiceAsync();

            var mappedUser = _mapper.Map<IEnumerable<UserViewModel?>?>(user);

            return new GetUsersResponse
            {
                usersViewModel = mappedUser
            };

        }
    }
}
