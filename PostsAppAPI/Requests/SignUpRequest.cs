namespace PostsAppAPI.Requests
{
    public class SignUpRequest
    {
        public string Email { get; set; }
        public string Handle { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}