using DataAccess.AbstractDao;
using DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class GenericNumberValidator
    {
        private static String GetMessage(String MessageId)
        {
            MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
            return MessageDao.GetById(MessageId);
        }

        private static String GetMessage(String MinRange, String MaxRange)
        {
            String ErrorMessage = GetMessage(Constants.NumberRangeFieldErrorMessage) + MinRange + GetMessage(Constants.AndRangeFieldMessage) + MaxRange;

            return ErrorMessage;
        }

        public static String GetValidationErrorMessage(int NumberToValidate, int MinRange, int MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = GetMessage(MinRange.ToString(), MaxRange.ToString());
            }

            return ErrorMessage;
        }

        public static String GetValidationErrorMessage(float NumberToValidate, float MinRange, float MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = GetMessage(MinRange.ToString(), MaxRange.ToString());
            }

            return ErrorMessage;
        }

        public static String GetValidationErrorMessage(Double NumberToValidate, Double MinRange, Double MaxRange)
        {
            String ErrorMessage = String.Empty;

            if (NumberToValidate < MinRange || NumberToValidate > MaxRange)
            {
                ErrorMessage = GetMessage(MinRange.ToString(), MaxRange.ToString());
            }

            return ErrorMessage;
        }
    }
}
