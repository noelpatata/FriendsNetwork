using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendsNetwork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(
        IUseCase<GetUsersRequest, AppResponse<GetUsersResponse>> getUsersUseCase,
        IUseCase<CreateUserRequest, AppResponse<CreateUserResponse>> createUserUseCase)
        : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AppResponse<GetUsersResponse>>> GetAll()
        {
            var request = new GetUsersRequest();
            var response = await getUsersUseCase.ExecuteAsync(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AppResponse<CreateUserResponse>>> Create([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await createUserUseCase.ExecuteAsync(request);
            if (!response.success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
