namespace PostsAppDAL.Contants
{
    internal class StoredProcedures
    {
        #region Posts

        public static readonly string CreatePost = "posts_app.sp_create_post";
        public static readonly string FindPostById = "posts_app.sp_find_post_by_id";
        public static readonly string FindUserPosts = "posts_app.sp_find_user_posts";

        #endregion Posts

        #region Users

        public static readonly string FindUserByEmailAndPassword = "posts_app.sp_find_user_by_email_and_password";
        public static readonly string FindUserByHandle = "posts_app.sp_find_user_by_handle";
        public static readonly string SignUpUser = "posts_app.sp_sign_up_user";

        #endregion Users
    }
}
