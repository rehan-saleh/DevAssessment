using MockAuthentication.Models;

namespace AuthModule.Services
{
    public interface IAuthenticationService
    {
        AuthenticationReponse Login(string username, string password);
        void LogOut();
    }
}
