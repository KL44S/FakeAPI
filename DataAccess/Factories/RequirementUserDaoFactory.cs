using DataAccess.MemoryDao;
using DataAccess.SqlServerDao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public class RequirementUserDaoFactory : DaoFactory<RequirementUserDao>
    {
        protected override RequirementUserDao GetMemoryDaoInstance()
        {
            return new RequirementUserMemoryDao();
        }

        protected override RequirementUserDao GetSqlServerDaoInstance()
        {
            return new RequirementUserSqlServerDao();
        }
    }
}
