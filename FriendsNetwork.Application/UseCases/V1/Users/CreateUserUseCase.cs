using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.Users
{
    public class CreateUserUseCase(
    IHandler<CreateUserRequest, CreateUserResponse> handler,
    IValidator<CreateUserRequest> validator,
    IPresenter<CreateUserResponse> presenter)
    : IUseCase<CreateUserRequest, AppResponse<CreateUserResponse>>
    {
        private readonly IHandler<CreateUserRequest, CreateUserResponse> _handler = handler;
        private readonly IValidator<CreateUserRequest> _validator = validator;
        private readonly IPresenter<CreateUserResponse> _presenter = presenter;

        public async Task<AppResponse<CreateUserResponse>> ExecuteAsync(CreateUserRequest request)
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
                return new AppResponse<CreateUserResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
