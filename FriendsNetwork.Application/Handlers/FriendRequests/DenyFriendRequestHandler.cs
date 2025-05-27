using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;

namespace FriendsNetwork.Application.Handlers.FriendRequests
{
    public class DenyFriendRequestHandler(IDenyFriendRequestService denyFridnRequestService, IMapper mapper) : IHandler<DenyFriendRequestRequest, DenyFriendRequestResponse>
    {
        private readonly IDenyFriendRequestService _denyFridendRequestService = denyFridnRequestService ?? throw new ArgumentNullException(nameof(denyFridnRequestService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        public async Task<DenyFriendRequestResponse?> HandleAsync(DenyFriendRequestRequest? request)
        {
            var acceptedFriendRequest = await _denyFridendRequestService.DenyFriendRequestAsync(request!.userId, request.friendOnlineId);
            var mappedacceptedFriendRequest = _mapper.Map<FriendRequestViewModel?>(acceptedFriendRequest);
            var mappedAccepted = new DenyFriendRequestResponse
            {
                viewModel = mappedacceptedFriendRequest
            };
            return mappedAccepted;
        }
    }
}
