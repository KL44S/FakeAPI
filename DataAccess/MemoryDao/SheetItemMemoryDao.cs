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
                PartialQuantity = 0,
                PercentQuantity = 0
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
