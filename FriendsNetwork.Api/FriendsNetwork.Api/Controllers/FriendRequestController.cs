using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptFriendRequest([FromBody] AcceptFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await acceptFriendRequest.ExecuteAsync(r));
        }
        
        [Authorize]
        [HttpPost("deny")]
        public async Task<IActionResult> DenyFriendRequest([FromBody] DenyFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await denyFriendRequest.ExecuteAsync(r));
        }

        [Authorize]
        [HttpPost("send")]
        public async Task<IActionResult> SendFriendRequest([FromBody] SendFriendRequestRequest r)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            r.userId = userId;

            return Ok(await sendFriendRequest.ExecuteAsync(r));
        }
    
        [Authorize]
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

            return Ok(await getPendingFriendRequests.ExecuteAsync(request));
        }
    }
}
