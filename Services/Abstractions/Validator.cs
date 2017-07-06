using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public abstract class Validator
    {
        public Validator ValidatorSon { get; set; }
        private IValidatorType _validatorType;

        public Validator(IValidatorType ValidatorType)
        {
            this._validatorType = ValidatorType;
        }

        public abstract Boolean DoValidate();

        public Boolean Validate()
        {
            return this._validatorType.Validate(this);
        }
    }
}
