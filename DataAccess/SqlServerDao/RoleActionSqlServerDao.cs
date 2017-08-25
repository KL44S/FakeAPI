using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.EntityModel;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class RoleActionSqlServerDao : RoleActionDao
    {
        public override void Create(RoleAction Entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<RoleAction> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<RoleAction> GetAllByRoleId(int RoleId)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IList<RoleAction> RoleActions = new List<RoleAction>();
                EntityModel.Role Role = ObrasEntities.Role.FirstOrDefault(x => x.roleId.Equals(RoleId));

                if (Role == null)
                    throw new EntityNotFoundException();

                foreach (EntityModel.Action Action in Role.Action)
                {
                    RoleAction RoleAction = new RoleAction();
                    RoleAction.ActionId = Action.actionId;
                    RoleAction.RoleId = Role.roleId;

                    RoleActions.Add(RoleAction);
                }

                return RoleActions;
            }
        }

        public override RoleAction GetByRoleIdAndActionId(int RoleId, int ActionId)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Role Role = ObrasEntities.Role.FirstOrDefault(x => x.roleId.Equals(RoleId));

                if (Role == null)
                    throw new EntityNotFoundException();

                EntityModel.Action Action = Role.Action.FirstOrDefault(x => x.actionId.Equals(ActionId));

                if (Action == null)
                    throw new EntityNotFoundException();

                RoleAction RoleAction = new RoleAction();
                RoleAction.ActionId = Action.actionId;
                RoleAction.RoleId = Role.roleId;

                return RoleAction;
            }
        }

        public override void Update(RoleAction Entity)
        {
            throw new NotImplementedException();
        }
    }
}
