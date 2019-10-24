using System.Collections.Generic;
using System.Security.Claims;

namespace MockAuthentication.Models
{
    public interface IAuthContainer
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        List<Claim> Claims { get; set; }
    }
}
