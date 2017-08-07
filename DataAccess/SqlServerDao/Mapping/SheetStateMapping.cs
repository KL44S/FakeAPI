using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class SheetStateMapping : Mapping<Model.SheetState, EntityModel.SheetState>
    {
        protected override EntityModel.SheetState CreateEntity()
        {
            return new EntityModel.SheetState();
        }

        protected override Model.SheetState CreateModel()
        {
            return new Model.SheetState();
        }

        internal override void MapModel(Model.SheetState SheetStateModel, EntityModel.SheetState SheetStateEntity)
        {
            SheetStateEntity.description = SheetStateModel.Description;
            SheetStateEntity.sheetStateId = SheetStateModel.SheetStateId;
        }

        internal override void UnMapEntity(EntityModel.SheetState SheetStateEntity, Model.SheetState SheetStateModel)
        {
            SheetStateModel.Description = SheetStateEntity.description;
            SheetStateModel.SheetStateId = SheetStateEntity.sheetStateId;
        }
    }
}
