using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class SheetItemMapping : Mapping<Model.SheetItem, EntityModel.SheetItem>
    {
        protected override EntityModel.SheetItem CreateEntity()
        {
            return new EntityModel.SheetItem();
        }

        protected override Model.SheetItem CreateModel()
        {
            return new Model.SheetItem();
        }

        internal override void MapModel(Model.SheetItem SheetItemModel, EntityModel.SheetItem SheetItemEntity)
        {
            SheetItemEntity.requirementNumber = SheetItemModel.RequirementNumber;
            SheetItemEntity.itemNumber = SheetItemModel.ItemNumber;
            SheetItemEntity.subItemNumber = SheetItemModel.SubItemNumber;
            SheetItemEntity.sheetNumber = SheetItemModel.SheetNumber;
            SheetItemEntity.partialQuantity = SheetItemModel.PartialQuantity;
            SheetItemEntity.percentQuantity = SheetItemModel.PercentQuantity;
        }

        internal override void UnMapEntity(EntityModel.SheetItem SheetItemEntity, Model.SheetItem SheetItemModel)
        {
            SheetItemModel.RequirementNumber = SheetItemEntity.requirementNumber;
            SheetItemModel.ItemNumber = SheetItemEntity.itemNumber;
            SheetItemModel.SubItemNumber = SheetItemEntity.subItemNumber;
            SheetItemModel.SheetNumber = SheetItemEntity.sheetNumber;
            SheetItemModel.PartialQuantity = SheetItemEntity.partialQuantity;
            SheetItemModel.PercentQuantity = SheetItemEntity.percentQuantity;
        }
    }
}
