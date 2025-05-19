using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FriendsNetwork.Application.Communication.V1.Requests.FriendRequests;
using FriendsNetwork.Application.Communication.V1.Requests.FriendResponse;
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Handlers;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Abstractions.Repositories;
using FriendsNetwork.Domain.Abstractions.UseCases;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Application.UseCases.V1.FriendRequests
{
    public class SendFriendRequestUseCase : GenericUseCase<SendFriendRequestRequest, SendFriendRequestResponse>
    {
        public SendFriendRequestUseCase(
            IHandler<SendFriendRequestRequest, SendFriendRequestResponse?> handler,
            IValidator<SendFriendRequestRequest?> validator,
            IPresenter<SendFriendRequestResponse> presenter)
            : base(handler, validator, presenter)
        {
        }
    }
}
