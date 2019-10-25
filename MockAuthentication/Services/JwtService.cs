using Microsoft.IdentityModel.Tokens;
using MockAuthentication.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public class JwtService : IJwtService
    {
        private IAuthContainer AuthContainer { get; }
        public JwtService(IAuthContainer authContainer)
        {
            AuthContainer = authContainer;
        }
        public string GenerateToken(List<Claim> claims)
        {
            if (claims == null || claims.Count == 0)
                throw new ArgumentException("Arguments to create token are not valid.");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(AuthContainer.ExpireMinutes),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(AuthContainer.SecretKey), AuthContainer.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private SecurityKey GetSymmetricSecurityKey(string secretKey)
        {
            byte[] symmetricKey = Convert.FromBase64String(secretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey(AuthContainer.SecretKey)
            };
        }
    }
}
