using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class GenericTextValidator
    {
        public static String GetValidationErrorMessage(String TextToValidate, int MinLength, int MaxLength)
        {
            String ErrorMessage = String.Empty;

            if (TextToValidate.Length < MinLength || TextToValidate.Length > MaxLength)
            {
                ErrorMessage = "Este campo debe tener entre " + MinLength.ToString() + " y " + MaxLength.ToString() + " caracteres";
            }

            return ErrorMessage;
        }
    }
}
