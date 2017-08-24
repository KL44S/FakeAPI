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
    public class SheetItemSqlServerDao : SheetItemDao
    {
        private SheetItemMapping _sheetItemMapping;

        public SheetItemSqlServerDao()
        {
            this._sheetItemMapping = new SheetItemMapping();
        }

        public override void Create(Model.SheetItem SheetItem)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SheetItem SheetItemEntity = this._sheetItemMapping.MapModel(SheetItem);

                ObrasEntities.SheetItem.Add(SheetItemEntity);
                ObrasEntities.SaveChanges();
            }
        }

        public override void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem.Where(x => x.requirementNumber.Equals(RequirementNumber)
                                                                                                    && x.itemNumber.Equals(ItemNumber));

                ObrasEntities.SheetItem.RemoveRange(SheetItemEntities);
                ObrasEntities.SaveChanges();
            }
        }

        public override void DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem.Where(x => x.requirementNumber.Equals(RequirementNumber)
                                                                            && x.itemNumber.Equals(ItemNumber) && x.subItemNumber.Equals(SubItemNumber));

                ObrasEntities.SheetItem.RemoveRange(SheetItemEntities);
                ObrasEntities.SaveChanges();
            }
        }

        public override IEnumerable<Model.SheetItem> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem;
                IEnumerable<Model.SheetItem> SheetItems = this._sheetItemMapping.UnMapEntities(SheetItemEntities);

                return SheetItems;
            }
        }

        public override IEnumerable<Model.SheetItem> GetAllByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem.Where(x => x.requirementNumber.Equals(RequirementNumber)
                                                                            && x.sheetNumber.Equals(SheetNumber));

                IEnumerable<Model.SheetItem> SheetItems = this._sheetItemMapping.UnMapEntities(SheetItemEntities);

                return SheetItems;
            }
        }

        public override IEnumerable<Model.SheetItem> GetAllFilledSheetItems(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem.Where(x => x.requirementNumber.Equals(RequirementNumber)
                                                            && x.subItemNumber.Equals(SubItemNumber) && x.itemNumber.Equals(ItemNumber));

                IEnumerable<Model.SheetItem> SheetItems = this._sheetItemMapping.UnMapEntities(SheetItemEntities);

                return SheetItems;
            }

        }

        public override IEnumerable<Model.SheetItem> GetSheetItemByRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber,
                                                                                                                    int ItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.SheetItem> SheetItemEntities = ObrasEntities.SheetItem.Where(x => x.requirementNumber.Equals(RequirementNumber)
                                                                            && x.sheetNumber.Equals(SheetNumber) && x.itemNumber.Equals(ItemNumber));

                IEnumerable<Model.SheetItem> SheetItems = this._sheetItemMapping.UnMapEntities(SheetItemEntities);

                return SheetItems;
            }
        }

        private EntityModel.SheetItem GetSheetItemEntityByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int SheetNumber,
                                                                                                            int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SheetItem SheetItemEntity = ObrasEntities.SheetItem.FirstOrDefault(x => x.requirementNumber.Equals(RequirementNumber)
                                                            && x.sheetNumber.Equals(SheetNumber) && x.itemNumber.Equals(ItemNumber)
                                                            && x.subItemNumber.Equals(SubItemNumber));

                if (SheetItemEntity != null)
                {
                    return SheetItemEntity;
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
        }

        public override Model.SheetItem GetSheetItemByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int SheetNumber,
                                                                                                            int ItemNumber, int SubItemNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SheetItem SheetItemEntity = this.GetSheetItemEntityByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(
                                                            RequirementNumber, SheetNumber, ItemNumber, SubItemNumber);

                Model.SheetItem SheetItem = this._sheetItemMapping.UnMapEntity(SheetItemEntity);
                return SheetItem;
            }
        }

        public override void Update(Model.SheetItem SheetItem)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SheetItem SheetItemEntity = ObrasEntities.SheetItem.FirstOrDefault(x => x.requirementNumber.Equals(SheetItem.RequirementNumber)
                                                            && x.sheetNumber.Equals(SheetItem.SheetNumber) && x.itemNumber.Equals(SheetItem.ItemNumber)
                                                            && x.subItemNumber.Equals(SheetItem.SubItemNumber));

                if (SheetItemEntity != null)
                {
                    this._sheetItemMapping.MapModel(SheetItem, SheetItemEntity);
                    ObrasEntities.SaveChanges();
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
        }
    }
}
