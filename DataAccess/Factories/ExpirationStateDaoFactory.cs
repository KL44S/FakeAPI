using DataAccess.AbstractDao;
using DataAccess.MemoryDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public class ExpirationStateDaoFactory : DaoFactory<ExpirationStateDao>
    {
        protected override ExpirationStateDao GetMemoryDaoInstance()
        {
            return new ExpirationStateMemoryDao();
        }

        protected override ExpirationStateDao GetSqlServerDaoInstance()
        {
            return new ExpirationStateMemoryDao();
        }
    }
}
