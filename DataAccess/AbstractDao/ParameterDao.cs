using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class ParameterDao : IDao<String>
    {
        public void Create(string Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(string Entity)
        {
            throw new NotImplementedException();
        }

        public abstract String GetParameterById(String Id);
    }
}
