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

        private void FillSheetItemsWithAccumulated(IEnumerable<SheetItem> SheetItems)
        {
            foreach (SheetItem SheetItem in SheetItems)
            {
                this.FillSheetItemWithAccumulated(SheetItem);
            }
        }

        private void FillSheetItemWithAccumulated(SheetItem SheetItem)
        {
            IEnumerable<SheetItem> SheetItems = this._sheetItemDao.GetAllFilledSheetItems(SheetItem.RequirementNumber, SheetItem.ItemNumber, 
                                                                                                SheetItem.SubItemNumber);

            SheetItem.AccumulatedQuantity = 0;
            SheetItem.AccumulatedPercent = 0;

            foreach (SheetItem SItem in SheetItems)
            {
                if (!SItem.SheetNumber.Equals(SheetItem.SheetNumber))
                {
                    SheetItem.AccumulatedQuantity += SItem.PartialQuantity;
                    SheetItem.AccumulatedPercent += SItem.PercentQuantity;
                }
            }

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
            this.FillSheetItemsWithAccumulated(SheetItems);

            return SheetItems;
        }

        public IEnumerable<SheetItem> GetSheetItemsFromRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber, 
                                                                                                        int ItemNumber)
        {
            if (RequirementNumber <= 0 || SheetNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            IEnumerable<SheetItem> SheetItems = this._sheetItemDao.GetSheetItemByRequirementNumberAndSheetNumberAndItemNumber(RequirementNumber,
                                                                                                                        SheetNumber, ItemNumber);
            this.FillSheetItemsWithAccumulated(SheetItems);

            return SheetItems;
        }

        public void Update(SheetItem SheetItem)
        {
            if (SheetItem == null)
                throw new ArgumentException();

            this._sheetItemDao.Update(SheetItem);
        }

        public void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            if (RequirementNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            this._sheetItemDao.DeleteAllByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);
        }

        public void DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            if (RequirementNumber <= 0 || SubItemNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            this._sheetItemDao.DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(RequirementNumber, ItemNumber, SubItemNumber);
        }

        public bool MayUserEditSubItem(string Cuit, SheetItem SheetItem)
        {
            return true;
        }

        public IDictionary<Attributes.SheetItem, string> GetValidationErrors(SheetItem SheetItem)
        {
            IDictionary<Attributes.SheetItem, string> ValidationErrors = new Dictionary<Attributes.SheetItem, string>();
            ISubItemService SubItemService = new SubItemService();
            this.FillSheetItemWithAccumulated(SheetItem);

            SubItem SubItem = SubItemService.GetSubItemByRequirementNumberAndItemNumberAndSubItemNumber(SheetItem.RequirementNumber, SheetItem.ItemNumber,
                                                                                                                SheetItem.SubItemNumber);
            decimal TotalQuantityAccumulated = SheetItem.PartialQuantity + SheetItem.AccumulatedQuantity;

            if ((float)TotalQuantityAccumulated > SubItem.TotalQuantity)
            {
                ValidationErrors.Add(Attributes.SheetItem.PartialQuantity, "Este valor excede la cantidad total del sub-item");
            }

            decimal TotalPercentAccumulated = SheetItem.PercentQuantity + SheetItem.AccumulatedPercent;

            if (TotalPercentAccumulated > 100)
            {
                ValidationErrors.Add(Attributes.SheetItem.PartialQuantity, "El porcentaje no puede ser mayor a 100");
            }

            decimal PartialPercent = TotalQuantityAccumulated * 100 / (decimal)SubItem.TotalQuantity;
            PartialPercent = Math.Round(PartialPercent, 2, MidpointRounding.AwayFromZero);
            TotalPercentAccumulated = Math.Round(TotalPercentAccumulated, 2, MidpointRounding.AwayFromZero);

            if (!PartialPercent.Equals(TotalPercentAccumulated))
            {
                ValidationErrors.Add(Attributes.SheetItem.PartialQuantity, "El porcentaje no coincide con la cantidad ingresada");
            }

            return ValidationErrors;
        }
    }
}
