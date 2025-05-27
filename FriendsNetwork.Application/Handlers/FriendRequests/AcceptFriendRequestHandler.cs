using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;

namespace FriendsNetwork.Application.Handlers.FriendRequests
{
    public class AcceptFriendRequestHandler(
        IAcceptFriendRequestService acceptFriendRequestService,
        IMapper mapper) : IHandler<AcceptFriendRequestRequest, AcceptFriendRequestResponse>
    {
        private readonly IAcceptFriendRequestService _acceptFriendRequestService = acceptFriendRequestService ?? throw new ArgumentNullException(nameof(acceptFriendRequestService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        public async Task<AcceptFriendRequestResponse?> HandleAsync(AcceptFriendRequestRequest? request)
        {
            var acceptedFriendRequest = await _acceptFriendRequestService.AcceptFriendRequestAsync(request!.userId, request!.friendOnlineId);
            var mappedacceptedFriendRequest = _mapper.Map<FriendRequestViewModel?>(acceptedFriendRequest);
            var mappedAccepted = new AcceptFriendRequestResponse
            {
                viewModel = mappedacceptedFriendRequest
            };
            return mappedAccepted;
        }
    }
}
