using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Friendships
{
    public class DeleteFriendShipUseCase(
    IHandler<DeleteFriendShipRequest, DeleteFriendShipResponse> handler,
    IValidator<DeleteFriendShipRequest> validator,
    IPresenter<DeleteFriendShipResponse> presenter)
    : IUseCase<DeleteFriendShipRequest, AppResponse<DeleteFriendShipResponse>>
    {
        private readonly IHandler<DeleteFriendShipRequest, DeleteFriendShipResponse> _handler = handler;
        private readonly IValidator<DeleteFriendShipRequest> _validator = validator;
        private readonly IPresenter<DeleteFriendShipResponse> _presenter = presenter;

        public async Task<AppResponse<DeleteFriendShipResponse>> ExecuteAsync(DeleteFriendShipRequest request)
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
                return new AppResponse<DeleteFriendShipResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
