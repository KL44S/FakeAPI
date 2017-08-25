using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class ExpirationStateMapping : Mapping<Model.ExpirationState, EntityModel.ExpirationState>
    {
        protected override EntityModel.ExpirationState CreateEntity()
        {
            return new EntityModel.ExpirationState();
        }

        protected override Model.ExpirationState CreateModel()
        {
            return new Model.ExpirationState();
        }

        internal override void MapModel(Model.ExpirationState ExpirationStateModel, EntityModel.ExpirationState ExpirationStateEntity)
        {
            ExpirationStateEntity.expirationStateId = ExpirationStateModel.ExpirationStateId;
            ExpirationStateEntity.description = ExpirationStateModel.Description;
        }

        internal override void UnMapEntity(EntityModel.ExpirationState ExpirationStateEntity, Model.ExpirationState ExpirationStateModel)
        {
            ExpirationStateModel.ExpirationStateId = ExpirationStateEntity.expirationStateId;
            ExpirationStateModel.Description = ExpirationStateEntity.description;
        }
    }
}
