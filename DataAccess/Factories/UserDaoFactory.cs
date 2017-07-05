using DataAccess.MemoryDao;
using DataAccess.SqlServerDao;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public class UserDaoFactory : DaoFactory<UserDao>
    {
        protected override UserDao GetMemoryDaoInstance()
        {
            return new UserMemoryDao();
        }

        protected override UserDao GetSqlServerDaoInstance()
        {
            return new UserSqlServerDao();
        }
    }
}
