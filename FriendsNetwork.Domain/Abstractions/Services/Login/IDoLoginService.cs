using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Abstractions.Services.Login
{
    public interface IDoLoginService
    {
        Task<string?> DoLoginServiceAsync(string? username, string? password);

    }
}
