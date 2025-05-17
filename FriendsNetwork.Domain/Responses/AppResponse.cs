
namespace FriendsNetwork.Domain.Responses
{
    public class AppResponse<T>
    {
        public bool success { get; set; }
        public string? message { get; set; } = "";
        public T? content { get; set; }
    }
}
