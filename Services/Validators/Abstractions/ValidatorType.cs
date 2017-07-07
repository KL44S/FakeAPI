using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Abstractions
{
    public abstract class ValidatorType
    {
        public IValidator FirstValidator;
        public IValidator SecondValidator;
        public ValidatorType ValidatorTypeSon { get; set; }

        public Boolean Validate()
        {
            if (this.FirstValidator == null && this.SecondValidator == null)
                throw new ArgumentNullException();

            Boolean ValidatorResult = false;

            if (this.FirstValidator != null)
            {
                ValidatorResult = this.FirstValidator.Validate();

                if (this.SecondValidator != null)
                {
                    ValidatorResult = this.DoValidate(ValidatorResult);
                }
            }
            else
            {
                ValidatorResult = this.SecondValidator.Validate();
            }

            return ValidatorResult;
        }

        protected abstract Boolean DoValidate(Boolean ValidatorResult);
    }
}
