using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Friendships
{
    public class DeleteFriendshipUseCase(
    IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse> handler,
    IValidator<DeleteFriendshipRequest> validator,
    IPresenter<DeleteFriendshipResponse> presenter)
    : IUseCase<DeleteFriendshipRequest, AppResponse<DeleteFriendshipResponse>>
    {
        private readonly IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse> _handler = handler;
        private readonly IValidator<DeleteFriendshipRequest> _validator = validator;
        private readonly IPresenter<DeleteFriendshipResponse> _presenter = presenter;

        public async Task<AppResponse<DeleteFriendshipResponse>> ExecuteAsync(DeleteFriendshipRequest request)
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
                return new AppResponse<DeleteFriendshipResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
