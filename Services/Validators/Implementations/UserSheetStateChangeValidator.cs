using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class UserSheetStateChangeValidator : IValidator
    {
        public String UserCuitToValidate { get; set; }
        public int OldSheetStateIdToValidate { get; set; }
        public int NewSheetStateIdToValidate { get; set; }

        public bool Validate()
        {
            //TODO: implementar si el usuario puede cambiar al estado que está queriendo cambiar
            throw new NotImplementedException();
        }
    }
}
