using AutoMapper;
using FriendsNetwork.Application.Communication.V1.ViewModels.Friendships;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Infrastructure.Mapping.V1
{
    internal class FriendShipProfile: Profile
    {
        public FriendShipProfile()
        {
            CreateMap<FriendShip, FriendShipViewModel>().ReverseMap();
        }
    }
}
