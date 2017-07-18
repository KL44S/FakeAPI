using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class ItemMapping : Mapping<Model.Item, EntityModel.Item>
    {
        protected override EntityModel.Item CreateEntity()
        {
            return new EntityModel.Item();
        }

        protected override Model.Item CreateModel()
        {
            return new Model.Item();
        }

        internal override void MapModel(Model.Item Model, EntityModel.Item Entity)
        {
            Entity.description = Model.Description;
            Entity.itemNumber = Model.ItemNumber;
            Entity.requirementNumber = Model.RequirementNumber;
        }

        internal override void UnMapEntity(EntityModel.Item Entity, Model.Item Model)
        {
            Model.Description = Entity.description;
            Model.ItemNumber = Entity.itemNumber;
            Model.RequirementNumber = Entity.requirementNumber;
        }
    }
}
