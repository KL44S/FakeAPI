using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.MemoryDao
{
    public class SheetStateMemoryDao : SheetStateDao
    {
        private static IList<SheetState> _sheetStates = new List<SheetState>()
        {
            new SheetState()
            {
                SheetStateId = 1,
                Description = "Ingresada parcial"
            },
            new SheetState()
            {
                SheetStateId = 2,
                Description = "Ingresada"
            },
            new SheetState()
            {
                SheetStateId = 3,
                Description = "Confirmada"
            },
            new SheetState()
            {
                SheetStateId = 4,
                Description = "Observada"
            },
            new SheetState()
            {
                SheetStateId = 5,
                Description = "Anulada"
            }
        };

        public override void Create(SheetState SheetState)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SheetState> GetAll()
        {
            return _sheetStates;
        }

        public override SheetState GetSheetState(int SheetStateId)
        {
            SheetState FoundSheetState = _sheetStates.FirstOrDefault(SheetState => SheetState.SheetStateId.Equals(SheetStateId));

            if (FoundSheetState != null)
                return FoundSheetState;

            throw new ArgumentException();
        }

        public override void Update(SheetState SheetState)
        {
            throw new NotImplementedException();
        }
    }
}
