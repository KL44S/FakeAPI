using DataAccess.AbstractDao;
using DataAccess.MemoryDao;
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
            throw new NotImplementedException();
        }
    }
}
