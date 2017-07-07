using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Abstractions
{
    public abstract class ValidatorType
    {
        public Boolean Validate(Validator Validator)
        {
            Validator ValidatorSon = Validator.ValidatorSon;

            if (ValidatorSon == null)
            {
                return Validator.Validate();
            }
            else
            {
                return this.DoValidate(Validator);
            }
        }

        protected abstract Boolean DoValidate(Validator Validator);
    }
}
