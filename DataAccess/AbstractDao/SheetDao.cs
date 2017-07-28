using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class SheetDao : IDao<Sheet>
    {
        public abstract void Create(Sheet Sheet);
        public abstract IEnumerable<Sheet> GetAll();
        public abstract void Update(Sheet Sheet);
        public abstract IEnumerable<Sheet> GetAllByRequirementNumber(int RequirementNumber);
        public abstract Sheet GetSheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber);
        public abstract Sheet GetCurrentSheetByRequirementNumber(int RequirementNumber);
    }
}
