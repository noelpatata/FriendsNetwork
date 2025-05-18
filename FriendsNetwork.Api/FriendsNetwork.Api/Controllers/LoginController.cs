using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Login;

namespace FriendsNetwork_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>> _doLogin;

        public LoginController(
            IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>> doLogin)
        {
            _doLogin = doLogin;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] DoLoginRequest login)
        {
            var encalsulatedResponse = await _doLogin.ExecuteAsync(login);

            return Ok(encalsulatedResponse);
        }
    }
}
