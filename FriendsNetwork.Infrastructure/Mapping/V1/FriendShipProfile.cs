using AutoMapper;
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Infrastructure.Mapping.V1
{
    public class FriendShipProfile: Profile
    {
        public FriendShipProfile()
        {
            CreateMap<Friendship, FriendShipViewModel>().ReverseMap();
        }
    }
}
