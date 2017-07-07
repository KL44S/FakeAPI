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
    public class CertificationDaysValidator : IValidator
    {
        public int CertificationDaysToValidate { get; set; }
        public IDictionary<Requirement.Attributes, String> ErrorMessages { get; set; }
        private static int _minNumberRange = 15;
        private static int _maxNumberRange = 60;

        public bool Validate()
        {
            if (this.CertificationDaysToValidate <= 0)
                throw new ArgumentNullException();

            String ErrorMessage = GenericNumberValidator.GetValidationErrorMessage(this.CertificationDaysToValidate, _minNumberRange, _maxNumberRange);

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageService.PutErrorMessage(this.ErrorMessages, Requirement.Attributes.CertificationDays, ErrorMessage);

                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
