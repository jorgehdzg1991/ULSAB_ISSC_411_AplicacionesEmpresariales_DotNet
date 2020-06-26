using Dapper;
using MySql.Data.MySqlClient;
using PostsAppDAL.Config;
using PostsAppDAL.Contants;
using PostsAppModels.EnrichedEntities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PostsAppDAL
{
    public class PostsDataAccess
    {
        public static int CreatePost(string usersEmail, string title, string content)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("p_email", usersEmail);
                parameters.Add("p_title", title);
                parameters.Add("p_content", content);

                cnn.Execute(StoredProcedures.CreatePost, parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("p_id");
            }
        }

        public static UserPost FindPostById(int id)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_id", id);

                return cnn.Query<UserPost>(StoredProcedures.FindPostById, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public static List<UserPost> FindUserPosts(string email)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_email", email);

                return cnn.Query<UserPost>(StoredProcedures.FindUserPosts, parameters, commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
