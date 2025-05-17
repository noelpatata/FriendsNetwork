using AutoMapper;
using FriendsNetwork.Application.Communication.V1.ViewModels.Users;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Infrastructure.Mapping.V1
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
