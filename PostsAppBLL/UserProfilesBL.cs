using PostsAppDAL;
using PostsAppModels.EnrichedEntities;

namespace PostsAppBLL
{
    public class UsersProfilesBL
    {
        public static UsersProfile FindUserProfileByHandle(string handle)
        {
            var user = UsersDataAccess.FindUserByHandle(handle);
            var userPosts = PostsDataAccess.FindUserPosts(user.Email);

            return new UsersProfile(user, userPosts);
        }
    }
}
