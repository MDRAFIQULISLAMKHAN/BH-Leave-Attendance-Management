using System;
using System.Data;
using System.Data.SqlClient;
using TW.DataLayer;
using TW.Utility;

namespace TW.DataLayerSql
{
    public class SqlUserProvider : IUserProvider
    {
        public Models.User GetUserByUserNameNPassword(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetUserByUsernamePassword, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", username));
                command.Parameters.Add(new SqlParameter("@Password", password));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.User user = new Models.User();
                    user = UtilityManager.DataReaderMap<Models.User>(reader);
                    return user;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
