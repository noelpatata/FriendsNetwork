using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FriendsNetwork.Application.UseCases.V1.Users;
using FriendsNetwork.Application.Communication.V1.Responses.Users;
using FriendsNetwork.Application.Services.Users;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Abstractions.Services.Users;
using FriendsNetwork.Domain.Responses;
using FriendsNetwork.Infrastructure.Mapping.V1;
using FriendsNetwork.Infrastructure.Presenters.V1.Users;
using FriendsNetwork.Application.Communication.V1.Requests.Users;
using FriendsNetwork.Application.Handlers.Users;
using FriendsNetwork.Infrastructure.Validators.V1.Users;
using FriendsNetwork.PosgreSqlRepository;
using FriendsNetwork.FriendsNetwork.Infrastructure.Presenters.V1.Users;
using FriendsNetwork.Domain.Abstractions.Services.Security;
using FriendsNetwork.Infrastructure.Security;
using FriendsNetwork.Application.Communication.V1.Responses.Login;
using FriendsNetwork.Infrastructure.Presenters.V1.Login;
using FriendsNetwork.Domain.Abstractions.Services.Login;
using FriendsNetwork.Application.Communication.V1.Requests.Login;
using FriendsNetwork.Application.UseCases.V1.Login;
using FriendsNetwork.Infrastructure.Validators.V1.Login;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Infrastructure.Presenters.V1.Friendships;
using FriendsNetwork.Domain.Abstractions.Services.Friendships;
using FriendsNetwork.Application.Handlers.Friendships;
using FriendsNetwork.Application.Services.Friendships;
using FriendsNetwork.Application.Communication.V1.Requests.Friendships;
using FriendsNetwork.Application.UseCases.V1.Friendships;
using FriendsNetwork.Infrastructure.Validators.V1.Friendships;

namespace FriendsNetwork.Infrastructure.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //security
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //login
            services.AddScoped<IDoLoginService, DoLoginService>();

            //users
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<ICreateUserService, CreateUserService>();

            //friendships
            services.AddScoped<IGetFriendShipsService, GetFriendshipsService>();
            services.AddScoped<IDeleteFriendshipService, DeleteFriendshipService>();

            return services;
        }

        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            //login
            services.AddSingleton<IPresenter<DoLoginResponse>, DoLoginPresenter>();

            //users
            services.AddSingleton<IPresenter<GetUsersResponse>, GetUsersPresenter>();
            services.AddSingleton<IPresenter<CreateUserResponse>, CreateUserPresenter>();

            //friendships
            services.AddSingleton<IPresenter<GetFriendshipsResponse>, GetFriendshipsPresenter>();
            services.AddSingleton<IPresenter<DeleteFriendshipResponse>, DeleteFriendshipPresenter>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            //login
            services.AddScoped<IHandler<DoLoginRequest, DoLoginResponse>, DoLoginHandler>();

            //users
            services.AddScoped<IHandler<GetUsersRequest, GetUsersResponse>, GetUsersHandler>();
            services.AddScoped<IHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>();

            //friendships
            services.AddScoped<IHandler<GetFriendshipsRequest, GetFriendshipsResponse>, GetFriendshipsHandler>();
            services.AddScoped<IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse>, DeleteFriendshipHandler>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            //login
            services.AddScoped<IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>>, DoLoginUseCase>();

            //users
            services.AddScoped<IUseCase<GetUsersRequest, AppResponse<GetUsersResponse>>, GetUsersUseCase>();
            services.AddScoped<IUseCase<CreateUserRequest, AppResponse<CreateUserResponse>>, CreateUserUseCase>();

            //friendships
            services.AddScoped<IUseCase<GetFriendshipsRequest, AppResponse<GetFriendshipsResponse>>, GetFriendShipsUseCase>();
            services.AddScoped<IUseCase<DeleteFriendshipRequest, AppResponse<DeleteFriendshipResponse>>, DeleteFriendshipUseCase>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //login
            services.AddScoped<IValidator<DoLoginRequest>, DoLoginValidator>();

            //users
            services.AddScoped<IValidator<GetUsersRequest>, GetUsersValidator>();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserValidator>();

            //friendships
            services.AddScoped<IValidator<GetFriendshipsRequest>, GetFriendshipsValidator>();
            services.AddScoped<IValidator<DeleteFriendshipRequest>, DeleteFriendshipValidator>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //user repository
            services.AddScoped<IUserRepository, UserRepository>();

            //friendship repository
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(FriendShipProfile));
            return services;
        }
    }
}
