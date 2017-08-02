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
        void Update(SheetItem SheetItem);
    }
}
