using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsNetwork.Domain.Abstractions.Services.Security
{
    public interface ITokenGenerator
    {
        string? Generate(long? userId);
    }
}
