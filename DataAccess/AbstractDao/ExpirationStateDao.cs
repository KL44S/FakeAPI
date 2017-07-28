using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class ExpirationStateDao : IDao<ExpirationState>
    {
        public abstract void Create(ExpirationState Entity);
        public abstract IEnumerable<ExpirationState> GetAll();
        public abstract void Update(ExpirationState Entity);
        public abstract ExpirationState GetById(int ExpirationStateId);
    }
}
