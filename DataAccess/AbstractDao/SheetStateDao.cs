using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class SheetStateDao : IDao<SheetState>
    {
        public abstract void Create(SheetState SheetState);
        public abstract IEnumerable<SheetState> GetAll();
        public abstract void Update(SheetState SheetState);
        public abstract SheetState GetSheetState(int SheetStateId);
    }
}
