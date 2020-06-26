using PostsAppModels.Entities;

namespace PostsAppModels.EnrichedEntities
{
    public class UserPost : Post
    {
        public string UsersHandle { get; set; }
        public string UsersDisplayName { get; set; }
    }
}
