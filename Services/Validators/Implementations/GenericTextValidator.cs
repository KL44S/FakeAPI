using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.AbstractDao;
using DataAccess.Factories;

namespace Services.Validators.Implementations
{
    public class GenericTextValidator
    {
        private static String GetMessage(String MessageId)
        {
            MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
            return MessageDao.GetById(MessageId);
        }

        public static String GetValidationErrorMessage(String TextToValidate, int MinLength, int MaxLength)
        {
            String ErrorMessage = String.Empty;

            if (TextToValidate.Length < MinLength || TextToValidate.Length > MaxLength)
            {
                ErrorMessage = GetMessage(Constants.TextRangeFieldErrorMessage) + MinLength.ToString() + 
                                    GetMessage(Constants.AndRangeFieldMessage) + MaxLength.ToString() + GetMessage(Constants.TextRangeCharsErrorMessage);
            }

            return ErrorMessage;
        }
    }
}
