using DataAccess.AbstractDao;
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
    public class ItemDaoFactory : DaoFactory<ItemDao>
    {
        protected override ItemDao GetMemoryDaoInstance()
        {
            return new ItemMemoryDao();
        }

        protected override ItemDao GetSqlServerDaoInstance()
        {
            return new ItemSqlServerDao();
        }
    }
}
