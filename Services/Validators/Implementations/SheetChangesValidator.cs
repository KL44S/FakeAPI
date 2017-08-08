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
            if (!this._sheetWithChanges.FromDate.Year.Equals(this._currentSheet.FromDate.Year))
                return false;

            if (!this._sheetWithChanges.FromDate.Month.Equals(this._currentSheet.FromDate.Month))
                return false;

            if (!this._sheetWithChanges.FromDate.DayOfWeek.Equals(this._currentSheet.FromDate.DayOfWeek))
                return false;

            if (!this._sheetWithChanges.UntilDate.Year.Equals(this._currentSheet.UntilDate.Year))
                return false;

            if (!this._sheetWithChanges.UntilDate.Month.Equals(this._currentSheet.UntilDate.Month))
                return false;

            if (!this._sheetWithChanges.UntilDate.DayOfWeek.Equals(this._currentSheet.UntilDate.DayOfWeek))
                return false;

            return true;
        }
    }
}
