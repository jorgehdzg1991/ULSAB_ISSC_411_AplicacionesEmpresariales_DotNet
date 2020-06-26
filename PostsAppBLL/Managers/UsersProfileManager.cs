using PostsAppDAL;
using PostsAppModels.EnrichedEntities;

namespace PostsAppBLL.Managers
{
    public class UsersProfileManager
    {
        public static UsersProfile FindUserProfileByHandle(string handle)
        {
            var user = UsersDataAccess.FindUserByHandle(handle);
            var userPosts = PostsDataAccess.FindUserPosts(user.Email);

            return new UsersProfile(user, userPosts);
        }
    }
}
