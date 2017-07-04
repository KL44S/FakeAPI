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
    public class UserDaoFactory : DaoFactory<UserDao>
    {
        public override UserDao GetDaoInstance(Techs Tech)
        {
            switch (Tech)
            {
                case Techs.Memory:
                    return new UserMemoryDao();

                case Techs.SqlServer:
                    return new UserSqlServerDao();

                default:
                    throw new EntityNotFoundException();
            }
        }
    }
}
