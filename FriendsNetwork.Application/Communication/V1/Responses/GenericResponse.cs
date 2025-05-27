namespace FriendsNetwork.Application.Communication.V1.Responses;

public class GenericResponse<T>
{
    public T viewModel { get; set; } = default!;
}