using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators.Abstractions;

namespace Validators.Implementations
{
    public class OrValidatorType : ValidatorType
    {
        protected override bool DoValidate(Validator Validator)
        {
            return ( Validator.Validate() || Validator.ValidatorSon.Validate() );
        }
    }
}
