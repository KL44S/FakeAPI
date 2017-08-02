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
    public class PurchaseOrderExcerciseValidator : RangeFieldValidator, IValidator
    {
        public int PurchaseOrderExcerciseToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }
        private static int _minNumberRange;
        private static int _maxNumberRange;

        public PurchaseOrderExcerciseValidator() : base()
        {
            _minNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MinPurchaseOrderExcerciseParameter));
            _maxNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MaxPurchaseOrderExcerciseParameter));
        }

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
