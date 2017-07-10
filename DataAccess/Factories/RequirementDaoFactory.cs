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
    public class RequirementDaoFactory : DaoFactory<RequirementDao>
    {
        protected override RequirementDao GetMemoryDaoInstance()
        {
            return new RequirementMemoryDao();
        }

        protected override RequirementDao GetSqlServerDaoInstance()
        {
            return new RequirementSqlServerDao();
        }
    }
}
