using Microsoft.IdentityModel.Tokens;
using MockAuthentication.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(IAuthContainer authContainer)
        {
            if (authContainer == null || authContainer.Claims.Count == 0)
                throw new ArgumentException("Arguments to create token are not valid.");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authContainer.Claims),
                Expires = DateTime.UtcNow.AddMinutes(authContainer.ExpireMinutes),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(authContainer.SecretKey), authContainer.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityKey GetSymmetricSecurityKey(string secretKey)
        {
            byte[] symmetricKey = Convert.FromBase64String(secretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
