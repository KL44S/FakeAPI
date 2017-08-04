using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using Exceptions;

namespace Services.Implementations
{
    public class RoleActionService : IRoleActionService
    {
        private RoleActionDao _roleActionDao;

        public RoleActionService()
        {
            RoleActionDaoFactory RoleActionDaoFactory = new RoleActionDaoFactory();
            this._roleActionDao = RoleActionDaoFactory.GetDaoInstance();
        }

        public IEnumerable<int> GetAllActionsFromUser(User User)
        {
            if (User == null)
                throw new ArgumentException();

            IEnumerable<RoleAction> RoleActions = this._roleActionDao.GetAllByRoleId(User.RoleId);
            IList<int> Actions = new List<int>();

            foreach (RoleAction RoleAction in RoleActions)
            {
                Actions.Add(RoleAction.ActionId);
            }

            return Actions;
        }

        public bool HasUserAction(User User, int ActionId)
        {
            if (User == null || ActionId <= 0)
                throw new ArgumentException();

            try
            {
                RoleAction RoleAction = this._roleActionDao.GetByRoleIdAndActionId(User.RoleId, ActionId);
                return true;
            }
            catch (EntityNotFoundException)
            {
                return false;
            }
            
        }
    }
}
