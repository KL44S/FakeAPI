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
    public class SubItemSqlServerDao : SubItemDao
    {
        private SubItemMapping _subItemMappig;

        public SubItemSqlServerDao()
        {
            this._subItemMappig = new SubItemMapping();
        }

        private int GenerateAndGetNewSubItemNumber(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                int NewSubItemNumber = 1;

                EntityModel.SubItem LastSubItem = ObrasEntities.SubItem.Where(SubItem => SubItem.requirementNumber.Equals(RequirementNumber) 
                                                                                && SubItem.itemNumber.Equals(ItemNumber)).OrderByDescending(SubItem => SubItem.subItemNumber)
                                                                                .FirstOrDefault();

                if (LastSubItem != null)
                {
                    NewSubItemNumber = LastSubItem.subItemNumber + 1;
                }

                return NewSubItemNumber;
            }

        }

        private EntityModel.SubItem GetSubItemEntityByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemFound = ObrasEntities.SubItem.FirstOrDefault(SubItemEntity => SubItemEntity.requirementNumber.Equals(RequirementNumber)
                                                                && SubItemEntity.itemNumber.Equals(ItemNumber)
                                                                && SubItemEntity.subItemNumber.Equals(SubItemNumber));

                if (SubItemFound == null)
                    throw new EntityNotFoundException();

                return SubItemFound;
            }

        }

        public override void Create(Model.SubItem SubItem)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemEntity = this._subItemMappig.MapModel(SubItem);
                SubItemEntity.subItemNumber = this.GenerateAndGetNewSubItemNumber(SubItemEntity.requirementNumber, SubItemEntity.itemNumber);
                SubItem.SubItemNumber = SubItemEntity.subItemNumber;

                ObrasEntities.SubItem.Add(SubItemEntity);
                ObrasEntities.SaveChanges();
            }
        }

        public override void Delete(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemFound = ObrasEntities.SubItem.FirstOrDefault(SubItemEntity => SubItemEntity.requirementNumber.Equals(RequirementNumber)
                                                                && SubItemEntity.itemNumber.Equals(ItemNumber)
                                                                && SubItemEntity.subItemNumber.Equals(SubItemNumber));

                if (SubItemFound == null)
                    throw new EntityNotFoundException();

                ObrasEntities.SubItem.Remove(SubItemFound);
                ObrasEntities.SaveChanges();
            }
        }

        public override void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SubItem> SubItemEntities = ObrasEntities.SubItem.Where(SubItem => SubItem.requirementNumber.Equals(RequirementNumber)
                                                && SubItem.itemNumber.Equals(ItemNumber));

                if (SubItemEntities == null)
                    throw new EntityNotFoundException();

                ObrasEntities.SubItem.RemoveRange(SubItemEntities);
                ObrasEntities.SaveChanges();
            }
        }

        public override IEnumerable<Model.SubItem> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IList<EntityModel.SubItem> SubItemEntities = ObrasEntities.SubItem.ToList();
                IEnumerable<Model.SubItem> SubItems = this._subItemMappig.UnMapEntities(SubItemEntities);

                return SubItems;
            }
        }

        public override IEnumerable<Model.SubItem> GetAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SubItem> SubItemEntities = ObrasEntities.SubItem.Where(SubItem => SubItem.requirementNumber.Equals(RequirementNumber) 
                                                                                                && SubItem.itemNumber.Equals(ItemNumber));

                if (SubItemEntities == null)
                    throw new EntityNotFoundException();

                IEnumerable<Model.SubItem> SubItems = this._subItemMappig.UnMapEntities(SubItemEntities);

                return SubItems;
            }
        }

        public override Model.SubItem GetSubItemByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemFound = this.GetSubItemEntityByRequirementNumberAndItemNumberAndSubItemNumber(RequirementNumber, ItemNumber,
                                                                                                                            SubItemNumber);
                Model.SubItem SubItemModel = this._subItemMappig.UnMapEntity(SubItemFound);

                return SubItemModel;
            }
        }

        public override IEnumerable<Model.SubItem> GetSubItemsByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SubItem> SubItemEntities = ObrasEntities.SubItem.Where(SubItem => SubItem.requirementNumber.Equals(RequirementNumber));

                if (SubItemEntities == null)
                    throw new EntityNotFoundException();

                IEnumerable<Model.SubItem> SubItemModels = this._subItemMappig.UnMapEntities(SubItemEntities.ToList());

                return SubItemModels;
            }
        }

        public override void Update(Model.SubItem SubItem)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemFound = ObrasEntities.SubItem.FirstOrDefault(SubItemEntity => SubItemEntity.requirementNumber.Equals(SubItem.RequirementNumber)
                                                                                                && SubItemEntity.itemNumber.Equals(SubItem.ItemNumber) 
                                                                                                && SubItemEntity.subItemNumber.Equals(SubItem.SubItemNumber));

                if (SubItemFound == null)
                    throw new EntityNotFoundException();

                this._subItemMappig.MapModel(SubItem, SubItemFound);
                ObrasEntities.SaveChanges();
            }
        }
    }
}
