namespace PostsAppModels.Authentication
{
    public class Session
    {
        public string UserEmail { get; set; }
        public string UserHandle { get; set; }
        public string UserDisplayName { get; set; }
        public string UserBio { get; set; }
        public SessionToken Auth { get; set; }
        public SessionToken Refresh { get; set; }

        public Session(string userEmail, string userHandle, string userDisplayName, string userBio, SessionToken authToken, SessionToken refreshToken)
        {
            UserEmail = userEmail;
            UserHandle = userHandle;
            UserDisplayName = userDisplayName;
            UserBio = userBio;
            Auth = authToken;
            Refresh = refreshToken;
        }
    }
}
