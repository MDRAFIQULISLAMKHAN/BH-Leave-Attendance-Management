using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.DataLayerSql;
using TW.Models;

namespace TW.BusinessLayer
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
