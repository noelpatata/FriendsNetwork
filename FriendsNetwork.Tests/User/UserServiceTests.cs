using Moq;
using FriendsNetwork.Application.Services.Users;  // Adjust namespaces
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.Services.Security; // Assuming IUserRepository here

namespace FriendsNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IPasswordHasher> _passwordHasherMock;
        private CreateUserService _createUserService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _createUserService = new CreateUserService(
                _userRepositoryMock.Object,
                _passwordHasherMock.Object
                );
        }

        [Test]
        public void CreateUserServiceAsync_ShouldThrow_WhenPasswordIsNullOrWhitespace()
        {
            // Arrange
            string? username = "johndoe";
            string? password = " ";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() =>
                _createUserService.CreateUserServiceAsync(username, password));

            Assert.AreEqual("Password is required.", ex?.Message);
            _passwordHasherMock.Verify(h => h.HashPassword(It.IsAny<string>()), Times.Never);
            _userRepositoryMock.Verify(r => r.Add(It.IsAny<User>()), Times.Never);
        }
    }
}
