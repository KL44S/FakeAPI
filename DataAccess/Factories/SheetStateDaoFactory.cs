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
    public class SheetStateDaoFactory : DaoFactory<SheetStateDao>
    {
        protected override SheetStateDao GetMemoryDaoInstance()
        {
            return new SheetStateMemoryDao();
        }

        protected override SheetStateDao GetSqlServerDaoInstance()
        {
            return new SheetStateSqlServerDao();
        }
    }
}
