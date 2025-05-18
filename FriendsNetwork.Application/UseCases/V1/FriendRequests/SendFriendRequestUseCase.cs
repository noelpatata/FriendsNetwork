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
    public class SendFriendRequestUseCase(
        IHandler<SendFriendRequestRequest, SendFriendRequestResponse> handler,
        IValidator<SendFriendRequestRequest> validator,
        IPresenter<SendFriendRequestResponse> presenter)
        : IUseCase<SendFriendRequestRequest, AppResponse<SendFriendRequestResponse>>

    {
        private readonly IHandler<SendFriendRequestRequest, SendFriendRequestResponse> _handler = handler;
        private readonly IValidator<SendFriendRequestRequest> _validator = validator;
        private readonly IPresenter<SendFriendRequestResponse> _presenter = presenter;

        public async Task<AppResponse<SendFriendRequestResponse>> ExecuteAsync(SendFriendRequestRequest request)
        {
            try
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid) throw new Exception(validationResult.ToString());

                var result = await _handler.HandleAsync(request);

                return await _presenter.PresentAsync(result);

            }
            catch (Exception ex)
            {
                return new AppResponse<SendFriendRequestResponse>
                {
                    success = false,
                    message = ex.Message,
                    content = null
                };
            }
        }
    }
}
