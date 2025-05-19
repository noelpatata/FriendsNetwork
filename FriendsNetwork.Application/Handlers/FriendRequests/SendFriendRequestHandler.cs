using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;

namespace FriendsNetwork.Application.Handlers.FriendRequests
{
    public class SendFriendRequestHandler(ISendFriendRequestService sendFriendRequestService, IMapper mapper) : IHandler<SendFriendRequestRequest, SendFriendRequestResponse>
    {
        private readonly ISendFriendRequestService _sendFriendRequestService = sendFriendRequestService ?? throw new ArgumentNullException(nameof(sendFriendRequestService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        public async Task<SendFriendRequestResponse?> HandleAsync(SendFriendRequestRequest? request)
        {
            var acceptedFriendRequest = await _sendFriendRequestService.SendFriendRequestAsync(request!.userId, request.FriendOnlineId);
            var mappedacceptedFriendRequest = _mapper.Map<SendFriendRequestViewModel?>(acceptedFriendRequest);
            var mappedAccepted = new SendFriendRequestResponse
            {
                viewModel = mappedacceptedFriendRequest
            };
            return mappedAccepted;
        }
    }
}
