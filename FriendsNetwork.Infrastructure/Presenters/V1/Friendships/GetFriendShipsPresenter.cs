﻿
using FriendsNetwork.Application.Communication.V1.Responses.Friendships;
using FriendsNetwork.Domain.Abstractions.Presenters;
using FriendsNetwork.Domain.Responses;

namespace FriendsNetwork.Infrastructure.Presenters.V1.Friendships
{
    public class GetFriendshipsPresenter : IPresenter<GetFriendshipsResponse?>
    {
        public Task<AppResponse<GetFriendshipsResponse?>> PresentAsync(GetFriendshipsResponse? response)
        {
            var result = new AppResponse<GetFriendshipsResponse?>
            {
                success = true,
                content = response,
                message = "Friendships fetched successfully."
            };
            return Task.FromResult(result);
        }
    }
}
