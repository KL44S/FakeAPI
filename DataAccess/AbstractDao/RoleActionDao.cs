using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class RoleActionDao : IDao<RoleAction>
    {
        public abstract void Create(RoleAction Entity);
        public abstract IEnumerable<RoleAction> GetAll();
        public abstract RoleAction GetByRoleIdAndActionId(int RoleId, int ActionId);
        public abstract IEnumerable<RoleAction> GetAllByRoleId(int RoleId);
        public abstract void Update(RoleAction Entity);
    }
}
