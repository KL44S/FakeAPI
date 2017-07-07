using DataAccess;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators.Abstractions;

namespace Validators.Implementations
{
    public class ExistingRequirementNumberValidator : Validator
    {
        public int RequirementNumberToValidate { get; set; }
        public IDictionary<Requirement.Attributes, String> ErrorMessages { get; set; }
        private static String _errorMessageId = "existingRequirement";
        
        private MessageDao _messageDao;
        private RequirementDao _requirementDao;

        public ExistingRequirementNumberValidator(ValidatorType ValidatorType) : base(ValidatorType)
        {
            RequirementDaoFactory RequirementDaoFactory = new RequirementDaoFactory();
            MessageDaoFactory MessageDaoFactory = new MessageDaoFactory();

            this._messageDao = MessageDaoFactory.GetDaoInstance();
            this._requirementDao = RequirementDaoFactory.GetDaoInstance();
        }

        public override bool DoValidate()
        {
            if (this.RequirementNumberToValidate <= 0)
                throw new ArgumentNullException();

            try
            {
                this._requirementDao.GetRequirementByRequirementNumber(this.RequirementNumberToValidate);

                String ErrorMessage = this._messageDao.GetById(_errorMessageId);

                if (this.ErrorMessages.ContainsKey(Requirement.Attributes.RequirementNumber))
                {
                    this.ErrorMessages[Requirement.Attributes.RequirementNumber] = this.ErrorMessages[Requirement.Attributes.RequirementNumber]
                                                                                        + ", " + ErrorMessage;
                }
                else
                {
                    ErrorMessages.Add(Requirement.Attributes.RequirementNumber, ErrorMessage);
                }

                return false;
            }
            catch (EntityNotFoundException)
            {
                return true;
            }

        }
    }
}
