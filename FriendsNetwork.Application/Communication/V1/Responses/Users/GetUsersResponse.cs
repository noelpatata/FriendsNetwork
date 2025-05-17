using FriendsNetwork.Application.Communication.V1.ViewModels.Users;

namespace FriendsNetwork.Application.Communication.V1.Responses.Users
{
    public class GetUsersResponse
    {
        public IEnumerable<UserViewModel?>? usersViewModel { get; set; } = [];
    }
}
