using AutoMapper;
using FriendsNetwork.Application.Communication.V1.ViewModels.FriendRequests;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Infrastructure.Mapping.V1
{
    public class FriendRequestProfile : Profile
    {
        public FriendRequestProfile()
        {
            CreateMap<FriendRequest, FriendRequestViewModel>().ReverseMap();
            CreateMap<FriendRequest, SendFriendRequestViewModel>().ReverseMap();
        }
    }
}
