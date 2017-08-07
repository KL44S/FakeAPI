using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class SheetMapping : Mapping<Model.Sheet, EntityModel.Sheet>
    {
        protected override EntityModel.Sheet CreateEntity()
        {
            return new EntityModel.Sheet();
        }

        protected override Model.Sheet CreateModel()
        {
            return new Model.Sheet();
        }

        internal override void MapModel(Model.Sheet SheetModel, EntityModel.Sheet SheetEntity)
        {
            SheetEntity.fromDate = SheetModel.FromDate;
            SheetEntity.untilDate = SheetModel.UntilDate;
            SheetEntity.requirementNumber = SheetModel.RequirementNumber;
            SheetEntity.sheetNumber = SheetModel.SheetNumber;
            SheetEntity.sheetStateId = SheetModel.SheetStateId;
        }

        internal override void UnMapEntity(EntityModel.Sheet SheetEntity, Model.Sheet SheetModel)
        {
            SheetModel.FromDate = SheetEntity.fromDate;
            SheetModel.UntilDate = SheetEntity.untilDate;
            SheetModel.RequirementNumber = SheetEntity.requirementNumber;
            SheetModel.SheetNumber = SheetEntity.sheetNumber;
            SheetModel.SheetStateId = SheetEntity.sheetStateId;
        }
    }
}
