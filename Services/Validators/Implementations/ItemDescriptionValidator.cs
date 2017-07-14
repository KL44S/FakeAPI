using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class ItemDescriptionValidator : IValidator
    {
        public String ItemDescription { get; set; }
        private static int _minDescriptionLength = 1;
        private static int _maxDescriptionLength = 99;
        public IDictionary<Item.Attributes, String> ErrorMessages { get; set; }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this.ItemDescription))
            {
                this.ErrorMessages.Add(Item.Attributes.Description, Constants.EmptyFieldErrorMessage);
                return false;
            }
            else
            {
                String ErrorMessage = GenericTextValidator.GetValidationErrorMessage(this.ItemDescription, _minDescriptionLength, _maxDescriptionLength);

                if (!String.IsNullOrEmpty(ErrorMessage))
                {
                    this.ErrorMessages.Add(Item.Attributes.Description, ErrorMessage);
                    return false;
                }

                return true;
            }
        }
    }
}
