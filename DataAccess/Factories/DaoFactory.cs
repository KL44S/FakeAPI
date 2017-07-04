using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factories
{
    public abstract class DaoFactory<T>
    {
        public enum Techs { SqlServer, Memory };

        public abstract T GetDaoInstance(Techs Tech);
    }
}
