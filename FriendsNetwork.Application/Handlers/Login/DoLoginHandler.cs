using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Application.Communication.V1.ViewModels.Login;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Login;

public class DoLoginHandler : IHandler<DoLoginRequest, DoLoginResponse>
{
    private readonly IDoLoginService _doLoginService;
    private readonly IMapper _mapper;

    public DoLoginHandler(IDoLoginService doLoginService, IMapper mapper)
    {
        _doLoginService = doLoginService;
        _mapper = mapper;
    }

    public async Task<DoLoginResponse> HandleAsync(DoLoginRequest request)
    {
        var token = await _doLoginService.DoLoginServiceAsync(request.username, request.password);
        var mappedToken = new LoginViewModel
        {
            token = token
        };

        return new DoLoginResponse
        {
            tokenViewModel = mappedToken
        };
    }
}
