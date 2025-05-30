using FluentValidation;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1
{
    public class GenericUseCase<TRequest, TResponse>(
        IHandler<TRequest, TResponse?> handler,
        IValidator<TRequest?> validator,
        IPresenter<TResponse> presenter)
        : IUseCase<TRequest, AppResponse<TResponse?>>
    {
        public async Task<AppResponse<TResponse?>> ExecuteAsync(TRequest? request)
        {
            try
            {
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid) throw new Exception(validationResult.ToString());

                var result = await handler.HandleAsync(request);

                return await presenter.PresentAsync(result);

            }
            catch (Exception ex)
            {
                return new AppResponse<TResponse?>
                {
                    success = false,
                    message = ex.Message,
                    content = default!
                };
            }
        }
    }
}
