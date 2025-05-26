using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Login;

namespace FriendsNetwork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController(IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>> doLogin)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] DoLoginRequest login)
        {
            var encapsulatedResponse = await doLogin.ExecuteAsync(login);

            return Ok(encapsulatedResponse);
        }
    }
}
