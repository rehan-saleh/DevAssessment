using MockAuthentication.Models;
using System.Threading.Tasks;

namespace AuthModule.Services
{
    public interface IAuthenticationService
    {
        AuthenticationReponse Login(string username, string password);
        void LogOut();
        Task<string> CheckForTokenValidationAsync();
    }
}
