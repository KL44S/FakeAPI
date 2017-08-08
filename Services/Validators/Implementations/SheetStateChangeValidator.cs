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
        public int OldSheetStateIdToValidate { get; set; }
        public int NewSheetStateIdToValidate { get; set; }

        public bool Validate()
        {
            //TODO: implementar validación de si el nuevo estado puede preceder al anterior
            throw new NotImplementedException();
        }
    }
}
