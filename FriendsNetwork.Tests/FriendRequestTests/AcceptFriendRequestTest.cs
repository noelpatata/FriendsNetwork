//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
//using FriendsNetwork.Application.Services.FriendRequests;
//using FriendsNetwork.Application.Services.Users;
//using FriendsNetwork.Domain.Abstractions.Repositories;
//using FriendsNetwork.Domain.Abstractions.Services.Security;
//using FriendsNetwork.Domain.Entities;
//using Moq;

//namespace FriendsNetwork.Tests.FriendRequest
//{
//    [TestFixture]
//    public class AcceptFriendRequestTest
//    {
//        private Mock<IFriendRequestRepository> _friendRequestRepo;
//        private AcceptFriendRequestService _acceptFriendRequestService;

//        [SetUp]
//        public void Setup()
//        {
//            // Mock the repository
//            _friendRequestRepo = new Mock<IFriendRequestRepository>();
//            _acceptFriendRequestService = new AcceptFriendRequestService(_friendRequestRepo.Object);
//        }

//        [Test]
//        public async Task CanAcceptFriendRequest()
//        {
//            // Arrange
//            var friendRequest = new FriendsNetwork.Domain.Entities.FriendRequest
//            {
//                id = 1,
//                sender_id = 2,
//                receiver_id = 1, // -> userId is the one who will accept the friend request
//                accepted = false
//            };

//            var userId = 1L;
//            var senderOnlineId = Guid.NewGuid();


//            // Mock the friend request query
//            _friendRequestRepo
//                .Setup(x => x.AcceptFriendRequest(userId, senderOnlineId))
//                .ReturnsAsync(() =>
//                {
//                    friendRequest.accepted = true;
//                    return friendRequest;
//                });

//            var service = new AcceptFriendRequestService(_friendRequestRepo.Object);

//            // Act
//            var result = await service.AcceptFriendRequestAsync(userId, senderOnlineId);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.accepted);
//        }
//    }
//}
