using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Users
{
    public class GetUsersUseCase(
    IHandler<GetUsersRequest, GetUsersResponse> handler,
    IValidator<GetUsersRequest> validator,
    IPresenter<GetUsersResponse> presenter)
    : IUseCase<GetUsersRequest, AppResponse<GetUsersResponse>>
    {
        private readonly IHandler<GetUsersRequest, GetUsersResponse> _handler = handler;
        private readonly IValidator<GetUsersRequest> _validator = validator;
        private readonly IPresenter<GetUsersResponse> _presenter = presenter;

        public async Task<AppResponse<GetUsersResponse>> ExecuteAsync(GetUsersRequest request)
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
                return new AppResponse<GetUsersResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
