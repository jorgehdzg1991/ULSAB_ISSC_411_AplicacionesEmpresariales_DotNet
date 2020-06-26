namespace PostsAppAPI.Requests
{
    public class CreatePostRequest
    {
        public string UsersEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}