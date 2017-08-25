using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.EntityModel;
using DataAccess.SqlServerDao.Mapping;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class ExpirationStateSqlServerDao : ExpirationStateDao
    {
        private ExpirationStateMapping _expirationStateMapping;

        public ExpirationStateSqlServerDao()
        {
            this._expirationStateMapping = new ExpirationStateMapping();
        }

        public override void Create(Model.ExpirationState Entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Model.ExpirationState> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.ExpirationState> ExpirationStatesEntities = ObrasEntities.ExpirationState.ToList();

                if (ExpirationStatesEntities == null)
                    throw new EntityNotFoundException();

                IEnumerable<Model.ExpirationState> ExpirationStates = this._expirationStateMapping.UnMapEntities(ExpirationStatesEntities);

                return ExpirationStates;
            }
        }

        public override Model.ExpirationState GetById(int ExpirationStateId)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.ExpirationState ExpirationStateEntity = ObrasEntities.ExpirationState.FirstOrDefault(x =>
                                                                        x.expirationStateId.Equals(ExpirationStateId));

                if (ExpirationStateEntity == null)
                    throw new EntityNotFoundException();

                Model.ExpirationState ExpirationState = this._expirationStateMapping.UnMapEntity(ExpirationStateEntity);

                return ExpirationState;
            }
        }

        public override void Update(Model.ExpirationState Entity)
        {
            throw new NotImplementedException();
        }
    }
}
