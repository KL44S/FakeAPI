using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class SheetItemMemoryDao : SheetItemDao
    {
        private static IList<SheetItem> _sheetItems = new List<SheetItem>()
        {
            new SheetItem()
            {
                ItemNumber = 1,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 17,
                PercentQuantity = 50
            },
            new SheetItem()
            {
                ItemNumber = 1,
                SubItemNumber = 2,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 0,
                PercentQuantity = 0
            },
            new SheetItem()
            {
                ItemNumber = 1,
                SubItemNumber = 3,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 0,
                PercentQuantity = 0
            },
            new SheetItem()
            {
                ItemNumber = 2,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 0,
                PercentQuantity = 0
            },
            new SheetItem()
            {
                ItemNumber = 2,
                SubItemNumber = 2,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 0,
                PercentQuantity = 0
            },
            new SheetItem()
            {
                ItemNumber = 3,
                SubItemNumber = 1,
                RequirementNumber = 1556,
                SheetNumber = 1,
                PartialQuantity = 0,
                PercentQuantity = 0
            }
        };

        public override void Create(SheetItem SheetItem)
        {
            _sheetItems.Add(SheetItem);
        }

        public override void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            List<SheetItem> SheetItemsAsList = _sheetItems.ToList();
            SheetItemsAsList.RemoveAll(x => x.RequirementNumber.Equals(RequirementNumber) && x.ItemNumber.Equals(ItemNumber));
            _sheetItems = SheetItemsAsList;
        }

        public override void DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            List<SheetItem> SheetItemsAsList = _sheetItems.ToList();
            SheetItemsAsList.RemoveAll(x => x.RequirementNumber.Equals(RequirementNumber) && x.ItemNumber.Equals(ItemNumber) 
                                                                                && x.SubItemNumber.Equals(SubItemNumber));
            _sheetItems = SheetItemsAsList;
        }

        public override IEnumerable<SheetItem> GetAll()
        {
            return _sheetItems;
        }

        public override IEnumerable<SheetItem> GetAllByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            IEnumerable<SheetItem> SheetItems = _sheetItems.Where(SheetItem => SheetItem.RequirementNumber.Equals(RequirementNumber) &&
                                                                    SheetItem.SheetNumber.Equals(SheetNumber));

            if (SheetItems == null)
                throw new EntityNotFoundException();

            return SheetItems;
        }

        public override IEnumerable<SheetItem> GetAllFilledSheetItems(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            IEnumerable<SheetItem> SheetItems = _sheetItems.Where(SheetItem => SheetItem.RequirementNumber.Equals(RequirementNumber) 
                                                                        && SheetItem.ItemNumber.Equals(ItemNumber) 
                                                                        && SheetItem.SubItemNumber.Equals(SubItemNumber));

            if (SheetItems == null)
                throw new EntityNotFoundException();

            return SheetItems;
        }

        public override IEnumerable<SheetItem> GetSheetItemByRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber, int ItemNumber)
        {
            IEnumerable<SheetItem> SheetItems = _sheetItems.Where(SheetItem => SheetItem.RequirementNumber.Equals(RequirementNumber) &&
                                                        SheetItem.SheetNumber.Equals(SheetNumber) && SheetItem.ItemNumber.Equals(ItemNumber));

            if (SheetItems == null)
                throw new EntityNotFoundException();

            return SheetItems;
        }

        public override SheetItem GetSheetItemByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int SheetNumber, 
                                                                                                                int ItemNumber, int SubItemNumber)
        {
            SheetItem FoundSheetItem = _sheetItems.FirstOrDefault(SheetItem => SheetItem.RequirementNumber.Equals(RequirementNumber) &&
                                                            SheetItem.SheetNumber.Equals(SheetNumber) && SheetItem.ItemNumber.Equals(ItemNumber)
                                                             && SheetItem.SubItemNumber.Equals(SubItemNumber));

            if (FoundSheetItem == null)
                throw new EntityNotFoundException();

            return FoundSheetItem;
        }

        public override void Update(SheetItem SheetItem)
        {
            //Nothing to do
        }
    }
}
