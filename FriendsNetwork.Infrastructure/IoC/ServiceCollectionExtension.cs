﻿using Microsoft.Extensions.DependencyInjection;
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
using FriendsNetwork.Domain.Abstractions.Services.FriendRequests;
using FriendsNetwork.Application.Services.FriendRequests;
using FriendsNetwork.Infrastructure.Presenters.V1.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.Notifications;
using FriendsNetwork.Application.Communication.V1.Responses.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Responses.Notifications;
using FriendsNetwork.Application.Handlers.FriendRequests;
using FriendsNetwork.Application.Handlers.Notifications;
using FriendsNetwork.Application.Services.Notifications;
using FriendsNetwork.Application.UseCases.V1.FriendRequests;
using FriendsNetwork.Application.UseCases.V1.Notifications;
using FriendsNetwork.Domain.Abstractions.Services.Notifications;
using FriendsNetwork.Infrastructure.Presenters.V1.Notifications;
using FriendsNetwork.Infrastructure.Validators.V1.FriendRequests;
using FriendsNetwork.Infrastructure.Validators.V1.Notifications;

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
            services.AddScoped<IGetByIdService, GetByIdService>();

            //friendships
            services.AddScoped<IGetFriendShipsService, GetFriendshipsService>();
            services.AddScoped<IDeleteFriendshipService, DeleteFriendshipService>();

            //friend requests
            services.AddScoped<ISendFriendRequestService, SendFriendRequestService>();
            services.AddScoped<IDenyFriendRequestService, DenyFriendRequestService>();
            services.AddScoped<IAcceptFriendRequestService, AcceptFriendRequestService>();
            services.AddScoped<IGetPendingFriendRequestsService, GetPendingFriendRequestsService>();
            
            //notifications
            services.AddScoped<ISaveNotificationService, SaveNotificationService>();
            services.AddScoped<IGetNonDeliveredService, GetNonDeliveredService>();
            services.AddScoped<IMarkAsDeliveredService, MarkAsDeliveredService>();

            return services;
        }

        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            //login
            services.AddSingleton<IPresenter<DoLoginResponse?>, DoLoginPresenter>();

            //users
            services.AddSingleton<IPresenter<GetUsersResponse?>, GetUsersPresenter>();
            services.AddSingleton<IPresenter<CreateUserResponse?>, CreateUserPresenter>();
            services.AddSingleton<IPresenter<GetByIdResponse?>, GetByIdPresenter>();

            //friendships
            services.AddSingleton<IPresenter<GetFriendshipsResponse?>, GetFriendshipsPresenter>();
            services.AddSingleton<IPresenter<DeleteFriendshipResponse?>, DeleteFriendshipPresenter>();

            //friend requests
            services.AddSingleton<IPresenter<SendFriendRequestResponse?>, SendFriendRequestPresenter>();
            services.AddSingleton<IPresenter<DenyFriendRequestResponse?>, DenyFriendRequestPresenter>();
            services.AddSingleton<IPresenter<AcceptFriendRequestResponse?>, AcceptFriendRequestPresenter>();
            services.AddSingleton<IPresenter<GetPendingFriendRequestsResponse?>, GetPendingFriendRequestsPresenter>();
            
            //notifications
            services.AddSingleton<IPresenter<SaveNotificationResponse?>, SaveNotificationPresenter>();
            services.AddSingleton<IPresenter<GetNonDeliveredResponse?>, GetNonDeliveredPresenter>();
            services.AddSingleton<IPresenter<MarkAsDeliveredResponse?>, MarkAsDeliveredPresenter>();
            
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            //login
            services.AddScoped<IHandler<DoLoginRequest, DoLoginResponse>, DoLoginHandler>();

            //users
            services.AddScoped<IHandler<GetUsersRequest, GetUsersResponse>, GetUsersHandler>();
            services.AddScoped<IHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>();
            services.AddScoped<IHandler<GetByIdRequest, GetByIdResponse>, GetByIdHandler>();

            //friendships
            services.AddScoped<IHandler<GetFriendshipsRequest, GetFriendshipsResponse>, GetFriendshipsHandler>();
            services.AddScoped<IHandler<DeleteFriendshipRequest, DeleteFriendshipResponse>, DeleteFriendshipHandler>();

            //friend requests
            services.AddScoped<IHandler<SendFriendRequestRequest, SendFriendRequestResponse>, SendFriendRequestHandler>();
            services.AddScoped<IHandler<DenyFriendRequestRequest, DenyFriendRequestResponse>, DenyFriendRequestHandler>();
            services.AddScoped<IHandler<AcceptFriendRequestRequest, AcceptFriendRequestResponse>, AcceptFriendRequestHandler>();
            services.AddScoped<IHandler<GetPendingFriendRequestsRequest, GetPendingFriendRequestsResponse>, GetPendingFriendRequestsHandler>();
            
            //notifications
            services.AddScoped<IHandler<SaveNotificationRequest, SaveNotificationResponse>, SaveNotificationHandler>();
            services.AddScoped<IHandler<GetNonDeliveredRequest, GetNonDeliveredResponse>, GetNonDeliveredHandler>();
            services.AddScoped<IHandler<MarkAsDeliveredRequest, MarkAsDeliveredResponse>, MarkAsDeliveredHandler>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            //login
            services.AddScoped<IUseCase<DoLoginRequest, AppResponse<DoLoginResponse?>>, DoLoginUseCase>();

            //users
            services.AddScoped<IUseCase<GetUsersRequest, AppResponse<GetUsersResponse?>>, GetUsersUseCase>();
            services.AddScoped<IUseCase<CreateUserRequest, AppResponse<CreateUserResponse?>>, CreateUserUseCase>();
            services.AddScoped<IUseCase<GetByIdRequest, AppResponse<GetByIdResponse?>>, GetByIdUseCase>();
            //friendships
            services.AddScoped<IUseCase<GetFriendshipsRequest, AppResponse<GetFriendshipsResponse?>>, GetFriendshipsUseCase>();
            services.AddScoped<IUseCase<DeleteFriendshipRequest, AppResponse<DeleteFriendshipResponse?>>, DeleteFriendshipUseCase>();

            services.AddScoped<IUseCase<SendFriendRequestRequest, AppResponse<SendFriendRequestResponse?>>, SendFriendRequestUseCase>();
            services.AddScoped<IUseCase<DenyFriendRequestRequest, AppResponse<DenyFriendRequestResponse?>>, DenyFriendRequestUseCase>();
            services.AddScoped<IUseCase<AcceptFriendRequestRequest, AppResponse<AcceptFriendRequestResponse?>>, AcceptFriendRequestUseCase>();
            services.AddScoped<IUseCase<GetPendingFriendRequestsRequest, AppResponse<GetPendingFriendRequestsResponse?>>, GetPendingFriendRequestsUseCase>();
            
            //nofitications
            services.AddScoped<IUseCase<SaveNotificationRequest, AppResponse<SaveNotificationResponse?>>, SaveNotificationUseCase>();
            services.AddScoped<IUseCase<GetNonDeliveredRequest, AppResponse<GetNonDeliveredResponse?>>, GetNonDeliveredUseCase>();
            services.AddScoped<IUseCase<MarkAsDeliveredRequest, AppResponse<MarkAsDeliveredResponse?>>, MarkAsDeliveredUseCase>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //login
            services.AddScoped<IValidator<DoLoginRequest>, DoLoginValidator>();

            //users
            services.AddScoped<IValidator<GetUsersRequest>, GetUsersValidator>();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserValidator>();
            services.AddScoped<IValidator<GetByIdRequest>, GetByIdValidator>();

            //friendships
            services.AddScoped<IValidator<GetFriendshipsRequest>, GetFriendshipsValidator>();
            services.AddScoped<IValidator<DeleteFriendshipRequest>, DeleteFriendshipValidator>();

            //friend requests
            services.AddScoped<IValidator<SendFriendRequestRequest>, SendFriendRequestValidator>();
            services.AddScoped<IValidator<DenyFriendRequestRequest>, DenyFriendRequestValidator>();
            services.AddScoped<IValidator<AcceptFriendRequestRequest>, AcceptFriendRequestValidator>();
            services.AddScoped<IValidator<GetPendingFriendRequestsRequest>, GetPendingFriendRequestsValidator>();
            
            //notifications
            services.AddScoped<IValidator<SaveNotificationRequest>, SaveNotificationValidator>();
            services.AddScoped<IValidator<GetNonDeliveredRequest>, GetNonDeliveredValidator>();
            services.AddScoped<IValidator<MarkAsDeliveredRequest>, MarkAsDeliveredValidator>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //user repository
            services.AddScoped<IUserRepository, UserRepository>();

            //friendship repository
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();

            //friend requests repository
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
            
            //notification repository
            services.AddScoped<INotificationRepository, NotificationRepository>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(FriendRequestProfile));
            services.AddAutoMapper(typeof(FriendShipProfile));
            services.AddAutoMapper(typeof(NotificationProfile));
            return services;
        }
    }
}
