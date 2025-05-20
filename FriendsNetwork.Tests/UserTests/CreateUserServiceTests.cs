﻿using AutoMapper;

using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Application.Handlers.Users;
using FriendsNetwork.Application.Services.Users;
using FriendsNetwork.Application.UseCases.V1.Users;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Entities;
using FriendsNetwork.FriendsNetwork.Infrastructure.Presenters.V1.Users;
using FriendsNetwork.Infrastructure.Mapping.V1;
using FriendsNetwork.Infrastructure.Security;
using FriendsNetwork.Infrastructure.Validators.V1.Users;
using Moq;


namespace FriendsNetwork.Tests.UserTests
{
    [TestFixture]
    public class CreateUserUseCaseTests
    {
        private CreateUserUseCase _useCase;
        private PasswordHasher _passwordHasher;
        private Mock<IUserRepository> _userRepositoryMock;
        private List<User> _inMemoryUsers;

        [SetUp]
        public void Setup()
        {
            // Initialize in-memory user repository
            _inMemoryUsers = new List<User>();
            _userRepositoryMock = new Mock<IUserRepository>();

            // Mock GetByUsername
            _userRepositoryMock.Setup(repo => repo.GetByUsername(It.IsAny<string>()))
                .ReturnsAsync((string username) =>
                    _inMemoryUsers.FirstOrDefault(u => u.username == username));

            // Mock GetAll
            _userRepositoryMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(() => _inMemoryUsers.Cast<User?>());

            // Mock Add
            _userRepositoryMock.Setup(repo => repo.Add(It.IsAny<User?>()))
                .ReturnsAsync((User? user) =>
                {
                    if (user != null)
                    {
                        user.online_id = Guid.NewGuid(); // Simulate DB-generated ID
                        _inMemoryUsers.Add(user);
                    }
                    return user;
                });

            // Create service, handler, etc. using the mocked repo
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<FriendRequestProfile>();
                cfg.AddProfile<FriendShipProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            _passwordHasher = new PasswordHasher(); // Or a mock if you prefer
            var service = new CreateUserService(_userRepositoryMock.Object, _passwordHasher);
            var handler = new CreateUserHandler(service, mapper);
            var validator = new CreateUserValidator();
            var presenter = new CreateUserPresenter();

            _useCase = new CreateUserUseCase(handler, validator, presenter);
        }


        [Test]
        public async Task CreateUserUseCase_InvalidPassword_ReturnsValidationError()
        {
            // Arrange

            var request = new CreateUserRequest
            {
                username = "validUsername",
                password = " " // Intentionally invalid (empty/whitespace)
            };

            // Act
            var result = await _useCase.ExecuteAsync(request);

            // Assert
            Assert.IsFalse(result.success);
            Assert.IsTrue(result.message.Contains("Password cannot be empty"));
        }

        [Test]
        public async Task CreateUserUseCase_InvalidUsername_ReturnsValidationError()
        {
            // Arrange

            var request = new CreateUserRequest
            {
                username = " ", // Intentionally invalid (empty/whitespace)
                password = "asdadadadad121"
            };

            // Act
            var result = await _useCase.ExecuteAsync(request);

            // Assert
            Assert.IsFalse(result.success);
            Assert.IsTrue(result.message.Contains("Username cannot be empty"));
        }

        [Test]
        public async Task CreateUserUseCase_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new CreateUserRequest
            {
                username = "validUsername",
                password = "validPassword123"
            };

            // Act
            var result = await _useCase.ExecuteAsync(request);

            // Assert
            Assert.IsTrue(result.success);
            Assert.That(result.message, Is.EquivalentTo("User created successfully."));
        }

        [Test]
        public async Task CreateUserUseCase_ValidRequest_StoresHashedPassword()
        {
            // Arrange
            var originalPassword = "validPassword123";
            var hashedPassword = _passwordHasher.HashPassword(originalPassword);

            var request = new CreateUserRequest
            {
                username = "testUser",
                password = originalPassword
            };

            // Act
            var result = await _useCase.ExecuteAsync(request);

            // Assert 
            var storedUser = _inMemoryUsers.FirstOrDefault(u => u.username == request.username);
            Assert.IsNotNull(storedUser, "User was not stored in repository.");

            // Verify the password is hashed (not plain text)
            Assert.AreNotEqual(originalPassword, storedUser.hashed_password, "Password was not hashed.");

            // Verify the hashed password matches the original password using PasswordHasher
            var isPasswordValid = _passwordHasher.VerifyPassword(originalPassword, storedUser.hashed_password, storedUser.salt);
            Assert.IsTrue(isPasswordValid, "Stored hashed password does not match original password.");
        }
    }
}