using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;
namespace FriendsNetwork.Application.UseCases.V1.Login
{
    public class DoLoginUseCase(
 IHandler<DoLoginRequest, DoLoginResponse> handler,
 IValidator<DoLoginRequest> validator,
 IPresenter<DoLoginResponse> presenter)
 : IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>>
    {
        private readonly IHandler<DoLoginRequest, DoLoginResponse> _handler = handler;
        private readonly IValidator<DoLoginRequest> _validator = validator;
        private readonly IPresenter<DoLoginResponse> _presenter = presenter;

        public async Task<AppResponse<DoLoginResponse>> ExecuteAsync(DoLoginRequest request)
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
                return new AppResponse<DoLoginResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }

}
