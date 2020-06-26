using PostsAppDAL;
using PostsAppModels.EnrichedEntities;

namespace PostsAppBLL.Managers
{
    public class PostsManager

    {
        public static UserPost CreatePost(string usersEmail, string title, string content, string authToken)
        {
            AuthManager.ValidateAuthToken(authToken, usersEmail);

            var postId = PostsDataAccess.CreatePost(usersEmail, title, content);

            return PostsDataAccess.FindPostById(postId);
        }
    }
}
