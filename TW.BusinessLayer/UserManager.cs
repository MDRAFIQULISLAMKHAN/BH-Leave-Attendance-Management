using BH.DataLayerSql;
using BH.Models;

namespace BH.BusinessLayer
{
    public class UserManager
    {
        public static User GetUserByUserNameNPassword(string userName, string password)
        {
            SqlUserProvider provider = new SqlUserProvider();
            return provider.GetUserByUserNameNPassword(userName, password);
        }
    }
}
