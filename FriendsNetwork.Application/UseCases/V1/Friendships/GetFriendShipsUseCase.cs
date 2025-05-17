using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Friendships
{
    public class GetFriendShipsUseCase(
    IHandler<GetFriendShipsRequest, GetFriendShipsResponse> handler,
    IValidator<GetFriendShipsRequest> validator,
    IPresenter<GetFriendShipsResponse> presenter)
    : IUseCase<GetFriendShipsRequest, AppResponse<GetFriendShipsResponse>>
    {
        private readonly IHandler<GetFriendShipsRequest, GetFriendShipsResponse> _handler = handler;
        private readonly IValidator<GetFriendShipsRequest> _validator = validator;
        private readonly IPresenter<GetFriendShipsResponse> _presenter = presenter;

        public async Task<AppResponse<GetFriendShipsResponse>> ExecuteAsync(GetFriendShipsRequest request)
        {
            try
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid) throw new Exception(validationResult.ToString());

                var result = await _handler.HandleAsync(request);
                return await _presenter.PresentAsync(result);

            }
            catch (Exception ex)
            {
                return new AppResponse<GetFriendShipsResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
