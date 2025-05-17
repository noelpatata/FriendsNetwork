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
    IHandler<GetFriendshipsRequest, GetFriendshipsResponse> handler,
    IValidator<GetFriendshipsRequest> validator,
    IPresenter<GetFriendshipsResponse> presenter)
    : IUseCase<GetFriendshipsRequest, AppResponse<GetFriendshipsResponse>>
    {
        private readonly IHandler<GetFriendshipsRequest, GetFriendshipsResponse> _handler = handler;
        private readonly IValidator<GetFriendshipsRequest> _validator = validator;
        private readonly IPresenter<GetFriendshipsResponse> _presenter = presenter;

        public async Task<AppResponse<GetFriendshipsResponse>> ExecuteAsync(GetFriendshipsRequest request)
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
                return new AppResponse<GetFriendshipsResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
