using DataAccess.Factories;
using DataAccess.AbstractDao;
using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class UnitOfMeasurementValidator : RangeFieldValidator, IValidator
    {
        public String UnitOfMeasurementToValidate { get; set; }
        private static int _minDescriptionLength;
        private static int _maxDescriptionLength;
        public IDictionary<Attributes.SubItem, String> ErrorMessages { get; set; }

        public UnitOfMeasurementValidator() : base()
        {
            _minDescriptionLength = int.Parse(this._parameterDao.GetParameterById(Constants.MinUnitOfMeasurementLengthParameter));
            _maxDescriptionLength = int.Parse(this._parameterDao.GetParameterById(Constants.MaxUnitOfMeasurementLengthParameter));
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this.UnitOfMeasurementToValidate))
            {
                MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
                String Message = MessageDao.GetById(Constants.EmptyFieldErrorMessage);

                this.ErrorMessages.Add(Attributes.SubItem.UnitOfMeasurement, Message);
                return false;
            }
            else
            {
                String ErrorMessage = GenericTextValidator.GetValidationErrorMessage(this.UnitOfMeasurementToValidate, _minDescriptionLength, _maxDescriptionLength);

                if (!String.IsNullOrEmpty(ErrorMessage))
                {
                    this.ErrorMessages.Add(Attributes.SubItem.UnitOfMeasurement, ErrorMessage);
                    return false;
                }

                return true;
            }
        }
    }
}
