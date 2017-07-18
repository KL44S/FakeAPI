using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class SubItemMapping : Mapping<Model.SubItem, EntityModel.SubItem>
    {
        protected override EntityModel.SubItem CreateEntity()
        {
            return new EntityModel.SubItem();
        }

        protected override Model.SubItem CreateModel()
        {
            return new Model.SubItem();
        }

        internal override void MapModel(Model.SubItem Model, EntityModel.SubItem Entity)
        {
            Entity.description = Model.Description;
            Entity.itemNumber = Model.ItemNumber;
            Entity.requirementNumber = Model.RequirementNumber;
            Entity.sis = Model.Sis;
            Entity.subItemNumber = Model.SubItemNumber;
            Entity.totalQuantity = (Decimal)(Model.TotalQuantity);
            Entity.unitOfMeasurement = Model.UnitOfMeasurement;
            Entity.unitPrice = (Decimal)Model.UnitPrice;
        }

        internal override void UnMapEntity(EntityModel.SubItem Entity, Model.SubItem Model)
        {
            Model.Description = Entity.description;
            Model.ItemNumber = Entity.itemNumber;
            Model.RequirementNumber = Entity.requirementNumber;
            Model.Sis = Entity.sis;
            Model.SubItemNumber = Entity.subItemNumber;
            Model.TotalQuantity = (float)(Entity.totalQuantity);
            Model.UnitOfMeasurement = Entity.unitOfMeasurement;
            Model.UnitPrice = (float)Entity.unitPrice;
        }
    }
}
