using DataAccess.AbstractDao;
using DataAccess.MemoryDao;
using DataAccess.SqlServerDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public class RoleActionDaoFactory : DaoFactory<RoleActionDao>
    {
        protected override RoleActionDao GetMemoryDaoInstance()
        {
            return new RoleActionMemoryDao();
        }

        protected override RoleActionDao GetSqlServerDaoInstance()
        {
            return new RoleActionSqlServerDao();
        }
    }
}
