using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DevAssessment.Models
{
    public class LoggedInUser
    {
        private List<Claim> Claims { get; }
        public LoggedInUser(string accessToken)
        {
            if (!(accessToken is null))
            {
                Claims = new JwtSecurityToken(accessToken).Claims.ToList();
                Role = GetClaim("role");
            }
        }

        public string Role { get; }

        private string GetClaim(string claimType)
        {
            return Claims.FirstOrDefault(x => x.Type == claimType).Value;
        }
    }
}
