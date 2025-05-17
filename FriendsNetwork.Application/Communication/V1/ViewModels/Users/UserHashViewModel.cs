namespace FriendsNetwork.Application.Communication.V1.ViewModels.Users
{
    public class UserHashViewModel
    {
        public long? userId { get; set; }
        public string? username { get; set; }
        public Guid? online_Id { get; set; }
        public string? hashed_password { get; set; }
        public string? salt { get; set; }
    }
}
