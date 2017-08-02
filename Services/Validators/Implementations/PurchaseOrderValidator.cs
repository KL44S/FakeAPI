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
    public class PurchaseOrderValidator : RangeFieldValidator, IValidator
    {
        public int PurchaseOrderToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }
        private static int _minNumberRange;
        private static int _maxNumberRange;

        public PurchaseOrderValidator() : base()
        {
            _minNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MinPurchaseOrderParameter));
            _maxNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MaxPurchaseOrderParameter));
        }

        public bool Validate()
        {
            if (this.PurchaseOrderToValidate <= 0)
                throw new ArgumentNullException();

            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.PurchaseOrderToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Attributes.Requirement.PurchaseOrder, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
