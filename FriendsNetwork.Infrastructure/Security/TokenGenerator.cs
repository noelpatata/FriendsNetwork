using System.Security.Claims;
using System.Text;
using FriendsNetwork.Domain.Abstractions.Services.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace FriendsNetwork.Infrastructure.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _config;
        public TokenGenerator(IConfiguration config)
        {
            _config = config;
        }
        public string? Generate(long? userId)
        {
            var issuer = _config["JwtSettings:Issuer"];
            var audience = _config["JwtSettings:Audience"];
            var key = Encoding.Default.GetBytes(_config["JwtSettings:Key"]);
            var encryptKey = Encoding.Default.GetBytes(_config["JwtSettings:EncryptKey"]);

            var claims = new[]
            {
            new Claim("userId", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var encryptingCredentials = new EncryptingCredentials(
                new SymmetricSecurityKey(encryptKey),
                SecurityAlgorithms.Aes128KW,
                SecurityAlgorithms.Aes128CbcHmacSha256
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(
                issuer,
                audience,
                new ClaimsIdentity(claims),
                DateTime.Now,
                DateTime.Now.AddHours(1),
                DateTime.Now,
                signingCredentials,
                encryptingCredentials);

            var jweToken = tokenHandler.WriteToken(token);
            return jweToken;
        }
    }
}
