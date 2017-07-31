using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class SheetChangesValidator : IValidator
    {
        private Sheet _sheetWithChanges;
        private Sheet _currentSheet;

        public SheetChangesValidator(Sheet CurrentSheet, Sheet SheetWithChanges)
        {
            this._sheetWithChanges = CurrentSheet;
            this._currentSheet = SheetWithChanges;
        }

        public bool Validate()
        {
            if (!this._sheetWithChanges.FromDate.Equals(this._currentSheet.FromDate))
                return false;

            if (!this._sheetWithChanges.UntilDate.Equals(this._currentSheet.UntilDate))
                return false;

            return true;
        }
    }
}
