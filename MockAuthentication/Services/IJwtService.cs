using System.Collections.Generic;
using System.Security.Claims;

namespace MockAuthentication.Services
{
    public interface IJwtService
    {
        string GenerateToken(List<Claim> claims);
        bool IsTokenValid(string token);
    }
}
