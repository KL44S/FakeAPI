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
        public abstract void Update(SheetItem SheetItem);
    }
}
