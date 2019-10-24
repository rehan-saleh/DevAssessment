using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace MockAuthentication.Models
{
    public class JwtContainer : IAuthContainer
    {
        public int ExpireMinutes { get; set; } = 10080; 
        public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public List<Claim> Claims { get; set; }
    }
}
