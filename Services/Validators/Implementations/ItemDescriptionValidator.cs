﻿using DataAccess.Factories;
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
    public class ItemDescriptionValidator : RangeFieldValidator, IValidator
    {
        public String ItemDescription { get; set; }
        private static int _minDescriptionLength;
        private static int _maxDescriptionLength;
        public IDictionary<Attributes.Item, String> ErrorMessages { get; set; }

        public ItemDescriptionValidator() : base()
        {
            _minDescriptionLength = int.Parse(this._parameterDao.GetParameterById(Constants.MinItemDescriptionLengthParameter));
            _maxDescriptionLength = int.Parse(this._parameterDao.GetParameterById(Constants.MaxItemDescriptionLengthParameter));
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this.ItemDescription))
            {
                MessageDao MessageDao = (new MessageDaoFactory()).GetDaoInstance();
                String Message = MessageDao.GetById(Constants.EmptyFieldErrorMessage);

                this.ErrorMessages.Add(Attributes.Item.Description, Message);
                return false;
            }
            else
            {
                String ErrorMessage = GenericTextValidator.GetValidationErrorMessage(this.ItemDescription, _minDescriptionLength, _maxDescriptionLength);

                if (!String.IsNullOrEmpty(ErrorMessage))
                {
                    this.ErrorMessages.Add(Attributes.Item.Description, ErrorMessage);
                    return false;
                }

                return true;
            }
        }
    }
}
