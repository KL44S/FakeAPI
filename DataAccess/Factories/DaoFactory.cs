using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public abstract class DaoFactory<T>
    {
        protected abstract T GetMemoryDaoInstance();
        protected abstract T GetSqlServerDaoInstance();

        public T GetDaoInstance()
        {
            return GetDaoInstance(Constants.CurrentTech);
        }

        public T GetDaoInstance(Constants.Techs Tech)
        {
            switch (Tech)
            {
                case Constants.Techs.Memory:
                    return this.GetMemoryDaoInstance();

                case Constants.Techs.SqlServer:
                    return this.GetSqlServerDaoInstance();

                default:
                    throw new ArgumentException();
            }
        }
    }
}
