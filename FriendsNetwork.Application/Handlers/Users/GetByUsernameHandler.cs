using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Users;

namespace FriendsNetwork.Application.Handlers.Users
{
    public class GetByUsernameHandler(IGetByUsernameService userGetService, IMapper mapper) : IHandler<GetByUsernameRequest, GetByUsernameResponse>
    {
        private readonly IGetByUsernameService _userGetService = userGetService ?? throw new ArgumentNullException(nameof(userGetService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<GetByUsernameResponse?> HandleAsync(GetByUsernameRequest? request)
        {
            var user = await _userGetService.GetByUsernameServiceAsync(request!.username);

            var mappedUser = _mapper.Map<UserViewModel?>(user);

            return new GetByUsernameResponse
            {
                viewModel = mappedUser
            };

        }
    }
}
