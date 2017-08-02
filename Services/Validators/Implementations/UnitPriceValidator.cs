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
    public class UnitPriceValidator : RangeFieldValidator, IValidator
    {
        public float UnitPriceToValidate { get; set; }
        public IDictionary<Attributes.SubItem, String> ErrorMessages { get; set; }
        private static float _minNumberRange;
        private static float _maxNumberRange;

        public UnitPriceValidator()
        {
            _minNumberRange = float.Parse(this._parameterDao.GetParameterById(Constants.MiUnitPricecParameter));
            _maxNumberRange = float.Parse(this._parameterDao.GetParameterById(Constants.MaxUnitPricecParameter));
        }

        public bool Validate()
        {
            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.UnitPriceToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessages.Add(Attributes.SubItem.UnitPrice, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
