using AutoMapper;
using FriendsNetwork.Application.Communication.V1.ViewModels.Notifications;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Infrastructure.Mapping.V1;

public class NotificationProfile: Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, NotificationViewModel>().ReverseMap();
    }
}