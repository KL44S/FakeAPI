using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.Mapping;
using DataAccess.SqlServerDao.EntityModel;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class ItemSqlServerDao : ItemDao
    {
        private ItemMapping _itemMapping;

        public ItemSqlServerDao()
        {
            this._itemMapping = new ItemMapping();
        }

        private int GenerateAndGetNewItemNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                int NewItemNumber = 1;

                EntityModel.Item LastItem = ObrasEntities.Item.Where(Item => Item.requirementNumber.Equals(RequirementNumber)).OrderBy(Item => Item.itemNumber)
                                                                        .FirstOrDefault();

                if (LastItem != null)
                {
                    NewItemNumber = LastItem.itemNumber + 1;
                }

                return NewItemNumber;
            }
        }

        public override void Create(Model.Item Item)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Item EntityItem = this._itemMapping.MapModel(Item);
                EntityItem.itemNumber = this.GenerateAndGetNewItemNumber(EntityItem.requirementNumber);

                ObrasEntities.Item.Add(EntityItem);
                ObrasEntities.SaveChanges();
            }
        }

        public override void Delete(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Item EntityItem = ObrasEntities.Item.FirstOrDefault(Item => Item.requirementNumber.Equals(RequirementNumber) && Item.itemNumber.Equals(ItemNumber));

                if (EntityItem == null)
                    throw new EntityNotFoundException();

                ObrasEntities.Item.Remove(EntityItem);
                ObrasEntities.SaveChanges();
            }
        }

        public override IEnumerable<Model.Item> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<Model.Item> Items = this._itemMapping.UnMapEntities(ObrasEntities.Item.ToList());

                return Items;
            }
        }

        public override IEnumerable<Model.Item> GetAllByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.Item> EntityItems = ObrasEntities.Item.Where(Item => Item.requirementNumber.Equals(RequirementNumber));

                if (EntityItems == null)
                    throw new EntityNotFoundException();

                IEnumerable<Model.Item> Items = this._itemMapping.UnMapEntities(EntityItems.ToList());

                return Items;
            }
        }

        public override Model.Item GetByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Item FoundEntityItem = ObrasEntities.Item.FirstOrDefault(EntityItem => EntityItem.requirementNumber.Equals(RequirementNumber) 
                                                                                                && EntityItem.itemNumber.Equals(ItemNumber));

                if (FoundEntityItem == null)
                    throw new EntityNotFoundException();

                Model.Item Item = this._itemMapping.UnMapEntity(FoundEntityItem);

                return Item;
            }
        }

        public override void Update(Model.Item Item)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Item FoundEntityItem = ObrasEntities.Item.FirstOrDefault(EntityItem => EntityItem.requirementNumber.Equals(Item.RequirementNumber) && 
                                                                                        EntityItem.itemNumber.Equals(Item.ItemNumber));

                if (FoundEntityItem == null)
                    throw new EntityNotFoundException();

                this._itemMapping.MapModel(Item, FoundEntityItem);
                ObrasEntities.SaveChanges();
            }
        }
    }
}
