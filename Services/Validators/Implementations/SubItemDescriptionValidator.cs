using DataAccess.Factories;
using DataAccess.AbstractDao;
using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class SubItemDescriptionValidator : IValidator
    {
        public String SubItemDescription { get; set; }
        private static int _minDescriptionLength = 1;
        private static int _maxDescriptionLength = 99;
        public IDictionary<Attributes.SubItem, String> ErrorMessages { get; set; }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this.SubItemDescription))
            {
                MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
                String Message = MessageDao.GetById(Constants.EmptyFieldErrorMessage);

                this.ErrorMessages.Add(Attributes.SubItem.Description, Message);
                return false;
            }
            else
            {
                String ErrorMessage = GenericTextValidator.GetValidationErrorMessage(this.SubItemDescription, _minDescriptionLength, _maxDescriptionLength);

                if (!String.IsNullOrEmpty(ErrorMessage))
                {
                    this.ErrorMessages.Add(Attributes.SubItem.Description, ErrorMessage);
                    return false;
                }

                return true;
            }
        }
    }
}
