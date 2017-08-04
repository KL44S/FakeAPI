using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class RoleActionMemoryDao : RoleActionDao
    {
        private static IList<RoleAction> _roleActions = new List<RoleAction>()
        {
            //ABM obras
            new RoleAction()
            {
                 ActionId = 1,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 2,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 3,
                 RoleId = 1
            },

            //ABM items
            new RoleAction()
            {
                 ActionId = 4,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 5,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 6,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 4,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 5,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 6,
                 RoleId = 2
            },
            
            //ABM sub-items
            new RoleAction()
            {
                 ActionId = 7,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 8,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 9,
                 RoleId = 1
            },
            new RoleAction()
            {
                 ActionId = 7,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 8,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 9,
                 RoleId = 2
            },

            //items de planilla
            new RoleAction()
            {
                 ActionId = 10,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 10,
                 RoleId = 3
            },

            //Ingresar una planilla
            new RoleAction()
            {
                 ActionId = 11,
                 RoleId = 2
            },
            new RoleAction()
            {
                 ActionId = 11,
                 RoleId = 3
            },

            //Observar/rechazar una planilla
            new RoleAction()
            {
                 ActionId = 12,
                 RoleId = 3
            },
            new RoleAction()
            {
                 ActionId = 13,
                 RoleId = 3
            },

           //Asignaciones
            new RoleAction()
            {
                 ActionId = 15,
                 RoleId = 1
            }
        };

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
            IEnumerable<RoleAction> RoleActions = _roleActions.Where(RoleAction => RoleAction.RoleId.Equals(RoleId)).ToList();

            if (RoleActions == null)
                throw new EntityNotFoundException();

            return RoleActions;
        }

        public override RoleAction GetByRoleIdAndActionId(int RoleId, int ActionId)
        {
            RoleAction RoleAction = _roleActions.FirstOrDefault(Raction => Raction.RoleId.Equals(RoleId) && Raction.ActionId.Equals(ActionId));

            if (RoleAction == null)
                throw new EntityNotFoundException();

            return RoleAction;
        }

        public override void Update(RoleAction Entity)
        {
            throw new NotImplementedException();
        }
    }
}
