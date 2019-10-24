using MockAuthentication.Models;

namespace MockAuthentication.Services
{
    public interface IJwtService
    {
        string GenerateToken(IAuthContainer authContainer);
    }
}
