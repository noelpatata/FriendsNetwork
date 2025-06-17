using AutoMapper;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Services.Users;

namespace FriendsNetwork.Application.Handlers.Users;

public class GetByIdHandler(IGetByIdService  getByIdService, IMapper mapper) : IHandler<GetByIdRequest, GetByIdResponse>
{
    public async Task<GetByIdResponse?> HandleAsync(GetByIdRequest? request)
    {
        //craeting
        var user = await getByIdService.GetByIdServiceAsync(request!.userId);
            
        //mapping
        var mappedUser = mapper.Map<UserViewModel?>(user);

        return new GetByIdResponse
        {
            viewModel = mappedUser
        };
    }
}