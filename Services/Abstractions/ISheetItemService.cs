using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ISheetItemService
    {
        void GenerateSheetItemsFromSheet(Sheet Sheet);
        IEnumerable<SheetItem> GetSheetItemsFromRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber);
        IEnumerable<SheetItem> GetSheetItemsFromRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber, int ItemNumber);
        void Update(SheetItem SheetItem);
        void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        void DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber);
    }
}
