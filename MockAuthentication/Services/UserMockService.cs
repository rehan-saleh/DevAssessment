using MockAuthentication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public class UserMockService : IUserMockService
    {
        private List<User> Users { get; set; }

        private IJwtService JwtService { get; }

        public UserMockService(IJwtService jwtService)
        {
            JwtService = jwtService;

            Users = new List<User>() {
                new User { Email="admin@ap.com", Password="test", Role=Role.Admin },
                new User { Email="rehan@ap.com", Password="test", Role=Role.User },
                new User { Email="test@ap.com", Password="test", Role=Role.User }
            };
        }

        public AuthenticationReponse Login(string username, string password)
        {
            AuthenticationReponse authenticationReponse = new AuthenticationReponse();

            User user = Users.FirstOrDefault(x => x.Email.ToLower().Equals(username) && x.Password.Equals(password));
            if (user != null)
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                authenticationReponse.AccessToken = JwtService.GenerateToken(claims);
                authenticationReponse.IsAuthenticated = true;
            }
            else
            {
                authenticationReponse.IsAuthenticated = false;
                authenticationReponse.Error = "Login failed.";
            }

            return authenticationReponse;
        }

        public bool CheckForTokenValidation(string token)
        {
            return JwtService.IsTokenValid(token);
        }
    }
}
