using PostsAppDAL;
using PostsAppModels.EnrichedEntities;

namespace PostsAppBLL
{
    public class PostsBL

    {
        public static UserPost CreatePost(string usersEmail, string title, string content, string authToken)
        {
            AuthenticationBL.ValidateAuthToken(authToken, usersEmail);

            var postId = PostsDataAccess.CreatePost(usersEmail, title, content);

            return PostsDataAccess.FindPostById(postId);
        }
    }
}
