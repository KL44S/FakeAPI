using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.MemoryDao
{
    public class SheetItemMemoryDao : SheetItemDao
    {
        public override void Create(SheetItem SheetItem)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SheetItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SheetItem> GetAllByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            throw new NotImplementedException();
        }

        public override void Update(SheetItem SheetItem)
        {
            throw new NotImplementedException();
        }
    }
}
