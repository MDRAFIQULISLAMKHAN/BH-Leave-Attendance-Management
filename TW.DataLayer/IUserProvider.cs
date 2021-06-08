using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface IUserProvider
    {
        User GetUserByUserNameNPassword(string userName, string password);
    }
}
