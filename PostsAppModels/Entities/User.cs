using System;

namespace PostsAppModels.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string Handle { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Status { get; set; }
    }
}
