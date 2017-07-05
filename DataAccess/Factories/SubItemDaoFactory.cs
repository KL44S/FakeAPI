using DataAccess.AbstractDao;
using DataAccess.MemoryDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public class SubItemDaoFactory : DaoFactory<SubItemDao>
    {
        protected override SubItemDao GetMemoryDaoInstance()
        {
            return new SubItemMemoryDao();
        }

        protected override SubItemDao GetSqlServerDaoInstance()
        {
            throw new NotImplementedException();
        }
    }
}
