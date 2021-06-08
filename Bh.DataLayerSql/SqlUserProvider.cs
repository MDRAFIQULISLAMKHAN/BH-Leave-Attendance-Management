using System;
using System.Data;
using System.Data.SqlClient;
using BH.DataLayer;
using BH.DataLayerSql;
using BH.Utility;
using BH.DataLayerSql;

namespace BH.DataLayerSql
{
    public class SqlUserProvider : IUserProvider
    {
        public BH.Models.User GetUserByUserNameNPassword(string username, string password)
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
                    BH.Models.User user = new BH.Models.User();
                    user = UtilityManager.DataReaderMap<BH.Models.User>(reader);
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
