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
    public class ParameterDaoFactory : DaoFactory<ParameterDao>
    {
        protected override ParameterDao GetMemoryDaoInstance()
        {
            return new ParameterMemoryDao();
        }

        protected override ParameterDao GetSqlServerDaoInstance()
        {
            return new ParameterSqlServerDao();
        }
    }
}
