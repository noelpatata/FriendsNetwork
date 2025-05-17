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

namespace FriendsNetwork.Infrastructure.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IDoLoginService, DoLoginService>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<ICreateUserService, CreateUserService>();
            
            return services;
        }

        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<IPresenter<DoLoginResponse>, DoLoginPresenter>();
            services.AddSingleton<IPresenter<GetUsersResponse>, GetUsersPresenter>();
            services.AddSingleton<IPresenter<CreateUserResponse>, CreateUserPresenter>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IHandler<DoLoginRequest, DoLoginResponse>, DoLoginHandler>();
            services.AddScoped<IHandler<GetUsersRequest, GetUsersResponse>, GetUsersHandler>();
            services.AddScoped<IHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<DoLoginRequest, AppResponse<DoLoginResponse>>, DoLoginUseCase>();
            services.AddScoped<IUseCase<GetUsersRequest, AppResponse<GetUsersResponse>>, GetUsersUseCase>();
            services.AddScoped<IUseCase<CreateUserRequest, AppResponse<CreateUserResponse>>, CreateUserUseCase>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<DoLoginRequest>, DoLoginValidator>();
            services.AddScoped<IValidator<GetUsersRequest>, GetUsersValidator>();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserValidator>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
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
