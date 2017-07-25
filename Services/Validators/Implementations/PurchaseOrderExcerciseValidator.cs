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
    public class PurchaseOrderExcerciseValidator : IValidator
    {
        public int PurchaseOrderExcerciseToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }
        private static int _minNumberRange = 1950;
        private static int _maxNumberRange = 2050;

        public bool Validate()
        {
            if (this.PurchaseOrderExcerciseToValidate <= 0)
                throw new ArgumentNullException();

            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.PurchaseOrderExcerciseToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Attributes.Requirement.PurchaseOrderExcercise, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
