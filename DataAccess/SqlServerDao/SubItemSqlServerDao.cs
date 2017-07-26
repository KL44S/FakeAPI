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

        public override void Create(Model.SubItem SubItem)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SubItem SubItemEntity = this._subItemMappig.MapModel(SubItem);

                ObrasEntities.SubItem.Add(SubItemEntity);
                ObrasEntities.SaveChanges();
            }
        }

        public override void Delete(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            throw new NotImplementedException();
        }

        public override void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override IEnumerable<Model.SubItem> GetSubItemsByRequirementNumber(int RequirementNumber)
        {
            throw new NotImplementedException();
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
