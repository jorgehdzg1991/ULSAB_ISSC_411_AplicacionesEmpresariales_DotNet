using System.Security.Claims;

namespace PostsAppJWT.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; }
        public string SecurityAlgorithm { get; set; }
        public int ExpireMinutes { get; set; }
        public Claim[] Claims { get; set; }

        public JWTContainerModel(string secretKey, string securityAlgorithm, int expireMinutes, Claim[] claims)
        {
            SecretKey = secretKey;
            SecurityAlgorithm = securityAlgorithm;
            ExpireMinutes = expireMinutes;
            Claims = claims;
        }
    }
}
