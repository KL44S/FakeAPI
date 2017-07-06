using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class MessageDao : IDao<String>
    {
        public abstract void Create(string Entity);
        public abstract IEnumerable<string> GetAll();
        public abstract void Update(string Entity);
        public abstract String GetById(String Id);
    }
}
