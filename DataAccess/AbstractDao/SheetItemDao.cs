using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class SheetItemDao : IDao<SheetItem>
    {
        public abstract void Create(SheetItem SheetItem);
        public abstract IEnumerable<SheetItem> GetAll();
        public abstract IEnumerable<SheetItem> GetAllByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber);
        public abstract IEnumerable<SheetItem> GetSheetItemByRequirementNumberAndSheetNumberAndItemNumber(int RequirementNumber, int SheetNumber, int ItemNumber);
        public abstract SheetItem GetSheetItemByRequirementNumberAndSheetNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int SheetNumber,
                                                                                                int ItemNumber, int SubItemNumber);
        public abstract IEnumerable<SheetItem> GetAllFilledSheetItems(int RequirementNumber, int ItemNumber, int SubItemNumber);
        public abstract void Update(SheetItem SheetItem);
        public abstract void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        public abstract void DeleteAllByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber);
    }
}
