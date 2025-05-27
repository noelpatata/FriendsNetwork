using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Handlers.Friendships
{
    public class GetFriendshipsHandler(IGetFriendShipsService getFriendShipsService, IMapper mapper) : IHandler<GetFriendshipsRequest, GetFriendshipsResponse>
    {
        private readonly IGetFriendShipsService _friendService = getFriendShipsService ?? throw new ArgumentNullException(nameof(getFriendShipsService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<GetFriendshipsResponse?> HandleAsync(GetFriendshipsRequest? request)
        {
            var friends = await _friendService.GetFriendShipsServiceAsync(request!.userId);

            var mappedFriends = _mapper.Map<IEnumerable<FriendShipViewModel?>?>(friends);

            return new GetFriendshipsResponse
            {
                viewModel = mappedFriends
            };

        }
    }
}
