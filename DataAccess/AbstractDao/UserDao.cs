using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class UserDao : IDao<User>
    {
        public abstract User GetUserByCuitAndPassword(String Cuit, String Password);
        public abstract User GetUserByCuit(String Cuit);
        public abstract void Create(User User);
        public abstract void Update(User User);
        public abstract IEnumerable<User> GetAll();
    }
}
