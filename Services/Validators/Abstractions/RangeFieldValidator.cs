using DataAccess.AbstractDao;
using DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Abstractions
{
    public abstract class RangeFieldValidator
    {
        protected ParameterDao _parameterDao;

        public RangeFieldValidator()
        {
            ParameterDaoFactory ParameterDaoFactory = new ParameterDaoFactory();
            this._parameterDao = ParameterDaoFactory.GetDaoInstance();
        }
    }
}
