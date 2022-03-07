using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Timesheets.SecurityLayer.Dto;

namespace Timesheets.SecurityLayer.Abstractions.Services
{
    public class SecurityService
    {
        protected static string GenerateJwtToken<TId>(TId id, string secretKey, int expiresMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(expiresMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        protected static RefreshToken GenerateRefreshToken<TId>(TId id, string secretKey, int expiresMinutes = 360)
        {
            var refreshToken = new RefreshToken
            {
                Expires = DateTime.UtcNow.AddMinutes(expiresMinutes),
                Token = GenerateJwtToken(id, secretKey, expiresMinutes)
            };
            return refreshToken;
        }

        public static byte[] GetPasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            using var sha1 = new SHA1CryptoServiceProvider();
            return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
        }

    }
}
