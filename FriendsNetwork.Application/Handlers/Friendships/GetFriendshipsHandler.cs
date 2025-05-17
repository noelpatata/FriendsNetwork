using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;

namespace FriendsNetwork.Application.Handlers.Friendships
{
    public class GetFriendShipsService(IGetFriendShipsService deleteFriendService, IMapper mapper) : IHandler<GetFriendShipsRequest, GetFriendShipsResponse>
    {
        private readonly IGetFriendShipsService _friendService = deleteFriendService ?? throw new ArgumentNullException(nameof(deleteFriendService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<GetFriendShipsResponse> HandleAsync(GetFriendShipsRequest request)
        {
            var friends = await _friendService.GetFriendShipsServiceAsync(request.userId);

            var mappedFriends = _mapper.Map<IEnumerable<FriendShipViewModel?>?>(friends);

            return new GetFriendShipsResponse
            {
                friendsViewModel = mappedFriends
            };

        }
    }
}
