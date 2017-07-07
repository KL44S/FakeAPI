using Services.Abstractions;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class OrValidatorType : ValidatorType
    {
        protected override bool DoValidate(Boolean ValidatorResult)
        {
            return (ValidatorResult || this.SecondValidator.Validate());
        }
    }
}
