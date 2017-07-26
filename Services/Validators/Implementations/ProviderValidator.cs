using DataAccess.Factories;
using DataAccess.AbstractDao;
using Model;
using Services.Implementations;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class ProviderValidator : IValidator
    {
        public String ProviderToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }
        private static int _minLength = 1;
        private static int _maxLength = 99;

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this.ProviderToValidate))
            {
                MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
                String Message = MessageDao.GetById(Constants.EmptyFieldErrorMessage);

                this.ErrorMessages.Add(Attributes.Requirement.Provider, Message);
                return false;
            }

            String ErrorMessage = GenericTextValidator.GetValidationErrorMessage(this.ProviderToValidate, _minLength, _maxLength);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Attributes.Requirement.Provider, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
