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
    public class CertificationDaysValidator : RangeFieldValidator, IValidator
    {
        public int CertificationDaysToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }
        private static int _minNumberRange;
        private static int _maxNumberRange;

        public CertificationDaysValidator() : base()
        {
            _minNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MinCertificationDaysParameter));
            _maxNumberRange = int.Parse(this._parameterDao.GetParameterById(Constants.MaxCertificationDaysParameter));
        }

        public bool Validate()
        {
            if (this.CertificationDaysToValidate <= 0)
                throw new ArgumentNullException();

            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.CertificationDaysToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Attributes.Requirement.CertificationDays, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
