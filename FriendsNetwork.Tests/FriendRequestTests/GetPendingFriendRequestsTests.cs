//using Moq;
//using FriendsNetwork.Application.Services.Users;  // Adjust namespaces
//using FriendsNetwork.Domain.Entities;
//using FriendsNetwork.Domain.Abstractions.Repositories;
//using FriendsNetwork.Domain.Abstractions.Services.Security;
//using FriendsNetwork.Application.Services.FriendRequests; // Assuming IUserRepository here

//namespace FriendsNetwork.Tests
//{
//    [TestFixture]
//    public class GetPendingFriendRequestsTests
//    {
//        private Mock<IFriendRequestRepository> _userRepositoryMock;
//        private GetPendingFriendRequestsService _getPendingFriendRequests;

//        [SetUp]
//        public void Setup()
//        {
//            //servicios de pruebas para no depender de bases de datos
//            _userRepositoryMock = new Mock<IFriendRequestRepository>();
//            _getPendingFriendRequests = new GetPendingFriendRequestsService(
//                _userRepositoryMock.Object
//                );
//        }

//        [Test]
//        public void GetPendingFriendRequestsServiceAsync_ShouldThrow_WhenPasswordIsNullOrWhitespace()
//        {
//            // Arrange
//            var friendRequests = new List<FriendsNetwork.Domain.Entities.FriendRequest>
//            {
//                new FriendsNetwork.Domain.Entities.FriendRequest
//                {
//                    id = 1,
//                    sender_id = 1,
//                    receiver_id = 2,
//                    accepted = false
//                }
//            };

//            // Act & Assert
//            var ex = Assert.ThrowsAsync<ArgumentException>(() =>
//                _getPendingFriendRequests.GetPendingFriendRequestsAsync(2));
//        }
//    }
//}
