using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;

namespace Services.Implementations
{
    public class SheetItemService : ISheetItemService
    {
        private SheetItemDao _sheetItemDao;

        public SheetItemService()
        {
            SheetItemDaoFactory SheetItemDaoFactory = new SheetItemDaoFactory();
            this._sheetItemDao = SheetItemDaoFactory.GetDaoInstance();
        }

        public void GenerateSheetItemsFromSheet(Sheet Sheet)
        {
            if (Sheet == null)
                throw new ArgumentException();

            ISubItemService SubItemService = new SubItemService();

            IEnumerable<SubItem> SubItems = SubItemService.GetSubItemsByRequirementNumber(Sheet.RequirementNumber);

            foreach (SubItem SubItem in SubItems)
            {
                SheetItem SheetItem = new SheetItem();
                SheetItem.RequirementNumber = SubItem.RequirementNumber;
                SheetItem.ItemNumber = SubItem.ItemNumber;
                SheetItem.SubItemNumber = SubItem.SubItemNumber;
                SheetItem.SheetNumber = Sheet.SheetNumber;

                this._sheetItemDao.Create(SheetItem);
            }
        }

        public IEnumerable<SheetItem> GetSheetItemsFromRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            if (RequirementNumber <= 0 || SheetNumber <= 0)
                throw new ArgumentException();

            IEnumerable<SheetItem> SheetItems = this._sheetItemDao.GetAllByRequirementNumberAndSheetNumber(RequirementNumber, SheetNumber);
            return SheetItems;
        }

        public IEnumerable<SheetItem> GetSheetItemsFromRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber, 
                                                                                                        int ItemNumber)
        {
            if (RequirementNumber <= 0 || SheetNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            IEnumerable<SheetItem> SheetItems = this._sheetItemDao.GetSheetItemByRequirementNumberAndSheetNumberAndItemNumber(RequirementNumber,
                                                                                                                        SheetNumber, ItemNumber);
            return SheetItems;
        }

        public void Update(SheetItem SheetItem)
        {
            if (SheetItem == null)
                throw new ArgumentException();

            SheetItem ExistingSheetItem = this._sheetItemDao.GetSheetItemByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(
                                               SheetItem.RequirementNumber, SheetItem.SheetNumber, SheetItem.ItemNumber, SheetItem.SubItemNumber);

            ExistingSheetItem.PartialQuantity = SheetItem.PartialQuantity;
            ExistingSheetItem.PercentQuantity = SheetItem.PercentQuantity;
        }
    }
}
