using System.Configuration;

namespace PostsAppDAL.Config
{
    internal class DatabaseConfig
    {
        public static readonly string DatabaseName = "posts_app";
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ToString();
    }
}
