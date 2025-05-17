namespace FriendsNetwork.Domain.Abstractions.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
