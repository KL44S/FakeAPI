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
    public class MessageDaoFactory : DaoFactory<MessageDao>
    {
        protected override MessageDao GetMemoryDaoInstance()
        {
            return new MessageMemoryDao();
        }

        protected override MessageDao GetSqlServerDaoInstance()
        {
            return new MessageSqlServerDao();
        }
    }
}
