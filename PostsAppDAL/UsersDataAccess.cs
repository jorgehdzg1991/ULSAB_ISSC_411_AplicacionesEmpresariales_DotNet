using Dapper;
using MySql.Data.MySqlClient;
using PostsAppDAL.Config;
using PostsAppDAL.Contants;
using PostsAppDAL.Exceptions;
using PostsAppModels.Entities;
using System.Data;
using System.Linq;

namespace PostsAppDAL
{
    public class UsersDataAccess
    {
        public static User FindUserByEmailAndPassword(string email, string password)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_email", email);
                parameters.Add("p_password", password);

                return cnn.Query<User>(StoredProcedures.FindUserByEmailAndPassword, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public static User FindUserByHandle(string handle)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("p_handle", handle);

                return cnn.Query<User>(StoredProcedures.FindUserByHandle, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public static void SignUpUser(string email, string handle, string displayName, string password)
        {
            using (var cnn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("p_email", email);
                    parameters.Add("p_handle", handle);
                    parameters.Add("p_display_name", displayName);
                    parameters.Add("p_password", password);

                    cnn.Execute(StoredProcedures.SignUpUser, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        throw new DuplicateKeyException(ex.Message);
                    }

                    throw ex;
                }
            }
        }
    }
}
