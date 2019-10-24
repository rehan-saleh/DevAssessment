using MockAuthentication.Models;

namespace MockAuthentication.Services
{
    public interface IUserMockService
    {
        AuthenticationReponse Login(string username, string password);
    }
}
