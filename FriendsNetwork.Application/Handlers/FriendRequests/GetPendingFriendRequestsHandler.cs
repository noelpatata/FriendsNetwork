using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;

namespace FriendsNetwork.Application.Handlers.FriendRequests
{
    public class GetPendingFriendRequestsHandler(IGetPendingFriendRequestsService getPendingFridendRequestsService, IMapper mapper) : IHandler<GetPendingFriendRequestsRequest, GetPendingFriendRequestsResponse>
    {
        private readonly IGetPendingFriendRequestsService _getPendingFridendRequestsService = getPendingFridendRequestsService ?? throw new ArgumentNullException(nameof(getPendingFridendRequestsService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        public async Task<GetPendingFriendRequestsResponse?> HandleAsync(GetPendingFriendRequestsRequest? request)
        {
            var acceptedFriendRequest = await _getPendingFridendRequestsService.GetPendingFriendRequestsAsync(request!.userId);
            var mappedacceptedFriendRequest = _mapper.Map<IEnumerable<FriendRequestViewModel?>?>(acceptedFriendRequest);
            var mappedAccepted = new GetPendingFriendRequestsResponse
            {
                viewModels = mappedacceptedFriendRequest
            };
            return mappedAccepted;
        }
    }
}
