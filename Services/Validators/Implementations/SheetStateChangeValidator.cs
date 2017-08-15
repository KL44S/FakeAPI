using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class SheetStateChangeValidator : IValidator
    {
        private int _oldSheetStateIdToValidate;
        private int _newSheetStateIdToValidate;

        public SheetStateChangeValidator(int OldSheetStateIdToValidate, int NewSheetStateIdToValidate)
        {
            this._oldSheetStateIdToValidate = OldSheetStateIdToValidate;
            this._newSheetStateIdToValidate = NewSheetStateIdToValidate;
        }

        private static IList<KeyValuePair<int, int>> _sheetStatesPossiblyChanges = new List<KeyValuePair<int, int>>()
        {
            new KeyValuePair<int, int>( Constants.PartialEnteredSheetStateId, Constants.EnteredSheetStateId ),
            new KeyValuePair<int, int>( Constants.EnteredSheetStateId, Constants.ApprovedSheetStateId ),
            new KeyValuePair<int, int>(  Constants.EnteredSheetStateId, Constants.ObservedSheetStateId ),
            new KeyValuePair<int, int>(  Constants.EnteredSheetStateId, Constants.RejectEnterSheetStateId ),
            new KeyValuePair<int, int>( Constants.ObservedSheetStateId,  Constants.EnteredSheetStateId ),
            new KeyValuePair<int, int>( Constants.ObservedSheetStateId, Constants.RejectEnterSheetStateId )
        };

        public bool Validate()
        {
            if (this._oldSheetStateIdToValidate <= 0 || this._newSheetStateIdToValidate <= 0)
                throw new ArgumentException();

            KeyValuePair<int, int> SheetStateChange = _sheetStatesPossiblyChanges.FirstOrDefault(s =>
                                                              s.Key.Equals(this._oldSheetStateIdToValidate)
                                                              && s.Value.Equals(this._newSheetStateIdToValidate));

            return (SheetStateChange.Key != 0 && SheetStateChange.Value != 0);
        }
    }
}
