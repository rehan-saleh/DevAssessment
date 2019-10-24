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

        private IAuthContainer AuthContainer { get; }

        public UserMockService(IJwtService jwtService, IAuthContainer authContainer)
        {
            JwtService = jwtService;
            AuthContainer = authContainer;

            Users = new List<User>() {
                new User { Email="rehan@test.com", Password="test", Role=Role.Admin },
                new User { Email="rehan@ap.com", Password="test", Role=Role.User }
            };
        }

        public AuthenticationReponse Login(string username, string password)
        {
            AuthenticationReponse authenticationReponse = new AuthenticationReponse();

            User user = Users.FirstOrDefault(x => x.Email.ToLower().Equals(username) && x.Password.Equals(password));
            if (user != null)
            {
                AuthContainer.Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                authenticationReponse.AccessToken = JwtService.GenerateToken(AuthContainer);
                authenticationReponse.IsAuthenticated = true;
            }
            else
            {
                authenticationReponse.IsAuthenticated = false;
                authenticationReponse.Error = "Login failed.";
            }

            return authenticationReponse;
        }
    }
}
