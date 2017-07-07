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
    public class PurchaseOrderValidator : IValidator
    {
        public int PurchaseOrderToValidate { get; set; }
        public IDictionary<Requirement.Attributes, String> ErrorMessages { get; set; }
        private static int _minNumberRange = 1;
        private static int _maxNumberRange = 9999999;

        public bool Validate()
        {
            if (this.PurchaseOrderToValidate <= 0)
                throw new ArgumentNullException();

            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.PurchaseOrderToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Requirement.Attributes.PurchaseOrder, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
