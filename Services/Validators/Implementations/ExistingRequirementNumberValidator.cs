using DataAccess;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using Exceptions;
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
    public class ExistingRequirementNumberValidator : IValidator
    {
        public int RequirementNumberToValidate { get; set; }
        public IDictionary<Attributes.Requirement, String> ErrorMessages { get; set; }     
        private MessageDao _messageDao;
        private RequirementDao _requirementDao;

        public ExistingRequirementNumberValidator()
        {
            RequirementDaoFactory RequirementDaoFactory = new RequirementDaoFactory();
            MessageDaoFactory MessageDaoFactory = new MessageDaoFactory();

            this._messageDao = MessageDaoFactory.GetDaoInstance();
            this._requirementDao = RequirementDaoFactory.GetDaoInstance();
        }

        public bool Validate()
        {
            if (this.RequirementNumberToValidate <= 0)
                throw new ArgumentNullException();

            try
            {
                this._requirementDao.GetRequirementByRequirementNumber(this.RequirementNumberToValidate);

                String ErrorMessage = this._messageDao.GetById(Constants.ExistingRequirementErrorMessage);
                MessageService.PutErrorMessage(this.ErrorMessages, Attributes.Requirement.RequirementNumber, ErrorMessage);

                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }

        }
    }
}
