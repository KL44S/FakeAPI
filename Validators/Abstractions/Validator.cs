using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Abstractions
{
    public abstract class Validator
    {
        public Validator ValidatorSon { get; set; }
        private ValidatorType _validatorType;

        public Validator(ValidatorType ValidatorType)
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
