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
    public class SheetItemDaoFactory : DaoFactory<SheetItemDao>
    {
        protected override SheetItemDao GetMemoryDaoInstance()
        {
            return new SheetItemMemoryDao();
        }

        protected override SheetItemDao GetSqlServerDaoInstance()
        {
            return new SheetItemSqlServerDao();
        }
    }
}
