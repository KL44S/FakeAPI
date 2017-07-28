using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ISheetService
    {
        void GenerateSheet(int RequirementNumber);
        IEnumerable<Sheet> GetAllSheetsFromRequirement(int RequirementNumber);
        Sheet GetSheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber);
        ExpirationState GetExpirationStateFromSheet(Sheet Sheet);
    }
}
