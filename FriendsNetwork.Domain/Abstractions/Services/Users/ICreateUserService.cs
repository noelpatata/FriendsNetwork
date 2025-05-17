using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsNetwork.Domain.Entities;

namespace FriendsNetwork.Domain.Abstractions.Services.Users
{
    public interface ICreateUserService
    {
        Task<User?> CreateUserServiceAsync(string? username, string? password);
    }
}
