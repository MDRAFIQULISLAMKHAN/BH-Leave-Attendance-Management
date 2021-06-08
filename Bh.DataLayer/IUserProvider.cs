using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Models;

namespace BH.DataLayer
{
    public interface IUserProvider
    {
        User GetUserByUserNameNPassword(string userName, string password);
    }
}
