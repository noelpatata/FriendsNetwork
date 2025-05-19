namespace FriendsNetwork.Domain.Abstractions.Handlers
{
    public interface IHandler<TRequest, TResponse>
    {
        Task<TResponse?> HandleAsync(TRequest? request);
    }
}
