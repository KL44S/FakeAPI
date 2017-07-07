using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class GenericNumberValidator
    {
        public static String GetValidationErrorMessage(int NumberToValidate, int MinRange, int MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = "Este campo debe estar entre " + MinRange.ToString() + " y " + MaxRange.ToString();
            }

            return ErrorMessage;
        }

        public static String GetValidationErrorMessage(float NumberToValidate, float MinRange, float MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = "Este campo debe estar entre " + MinRange.ToString() + " y " + MaxRange.ToString();
            }

            return ErrorMessage;
        }

        public static String GetValidationErrorMessage(Double NumberToValidate, Double MinRange, Double MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = "Este campo debe estar entre " + MinRange.ToString() + " y " + MaxRange.ToString();
            }

            return ErrorMessage;
        }
    }
}
