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
    public class SheetDaoFactory : DaoFactory<SheetDao>
    {
        protected override SheetDao GetMemoryDaoInstance()
        {
            return new SheetMemoryDao();
        }

        protected override SheetDao GetSqlServerDaoInstance()
        {
            return new SheetSqlServerDao();
        }
    }
}
