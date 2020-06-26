namespace PostsAppModels.Authentication
{
    public class SessionToken
    {
        public long ExpirationTime { get; set; }
        public string Token { get; set; }

        public SessionToken(long expirationTime, string token)
        {
            ExpirationTime = expirationTime;
            Token = token;
        }
    }
}
