using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class TotalQuantityValidator : RangeFieldValidator, IValidator
    {
        public float TotalQuantityToValidate { get; set; }
        public IDictionary<Attributes.SubItem, String> ErrorMessages { get; set; }
        private static float _minNumberRange;
        private static float _maxNumberRange;

        public TotalQuantityValidator() : base()
        {
            _minNumberRange = float.Parse(this._parameterDao.GetParameterById(Constants.MinTotalQuantityParameter));
            _maxNumberRange = float.Parse(this._parameterDao.GetParameterById(Constants.MaxTotalQuantityParameter));
        }

        public bool Validate()
        {
            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.TotalQuantityToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessages.Add(Attributes.SubItem.TotalQuantity, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
