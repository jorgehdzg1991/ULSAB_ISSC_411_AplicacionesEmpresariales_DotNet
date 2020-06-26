using PostsAppModels.Entities;
using System.Collections.Generic;

namespace PostsAppModels.EnrichedEntities
{
    public class UsersProfile : User
    {
        public List<UserPost> Posts { get; set; }

        public UsersProfile(User user, List<UserPost> posts)
        {
            Email = user.Email;
            Handle = user.Handle;
            DisplayName = user.DisplayName;
            Bio = user.Bio;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            Status = user.Status;
            Posts = posts;
        }
    }
}
