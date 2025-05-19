using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FriendsNetwork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendRequestController(
            IUseCase<AcceptFriendRequestRequest, AppResponse<AcceptFriendRequestResponse>> acceptFriendRequest,
            IUseCase<DenyFriendRequestRequest, AppResponse<DenyFriendRequestResponse>> denyFriendRequest,
            IUseCase<SendFriendRequestRequest, AppResponse<SendFriendRequestResponse>> sendFriendRequest,
            IUseCase<GetPendingFriendRequestsRequest, AppResponse<GetPendingFriendRequestsResponse>> getPendingFriendRequests) : ControllerBase
    {
        private readonly IUseCase<AcceptFriendRequestRequest, AppResponse<AcceptFriendRequestResponse>> _acceptFriendRequest = acceptFriendRequest;
        private readonly IUseCase<DenyFriendRequestRequest, AppResponse<DenyFriendRequestResponse>> _denyFriendRequest = denyFriendRequest;
        private readonly IUseCase<SendFriendRequestRequest, AppResponse<SendFriendRequestResponse>> _sendFriendRequest = sendFriendRequest;
        private readonly IUseCase<GetPendingFriendRequestsRequest, AppResponse<GetPendingFriendRequestsResponse>> _getPendingFriendRequests = getPendingFriendRequests;


        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriendRequest([FromBody] AcceptFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await _acceptFriendRequest.ExecuteAsync(r));
        }

        [HttpPost("deny")]
        public async Task<IActionResult> DenyFriendRequest([FromBody] DenyFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await _denyFriendRequest.ExecuteAsync(r));
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendFriendRequest([FromBody] SendFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await _sendFriendRequest.ExecuteAsync(r));
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingFriendRequests()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            var request = new GetPendingFriendRequestsRequest
            {
                userId = userId
            };

            return Ok(await _getPendingFriendRequests.ExecuteAsync(request));
        }
    }
}
