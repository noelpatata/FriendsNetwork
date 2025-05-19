using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendsNetwork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipController (
        IUseCase<GetFriendshipsRequest, AppResponse<GetFriendshipsResponse>> getFriendShipsService,
        IUseCase<DeleteFriendshipRequest, AppResponse<DeleteFriendshipResponse>> deleteFriendShipService) : ControllerBase
    {
        private readonly IUseCase<GetFriendshipsRequest, AppResponse<GetFriendshipsResponse>> _getFriendShipsUseCase = getFriendShipsService;
        private readonly IUseCase<DeleteFriendshipRequest, AppResponse<DeleteFriendshipResponse>> _deleteFriendUseCase = deleteFriendShipService;


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }
            GetFriendshipsRequest request = new GetFriendshipsRequest
            {
                userId = userId
            };

            return Ok(await _getFriendShipsUseCase.ExecuteAsync(request));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFriend([FromBody] DeleteFriendshipRequest request)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out long userId))
            {
                return Unauthorized("Invalid token");
            }

            request.userId = userId;

            return Ok(await _deleteFriendUseCase.ExecuteAsync(request));
        }
    }
}
