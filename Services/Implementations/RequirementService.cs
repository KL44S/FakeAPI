using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;
using DataAccess.Factories;
using DataAccess.MemoryDao;
using DataAccess.AbstractDao;
using Services.Validators.Abstractions;
using Services.Validators.Implementations;

namespace Services.Implementations
{
    public class RequirementService : IRequirementService
    {
        private RequirementDao _requirementDao;

        public RequirementService()
        {
            RequirementDaoFactory RequirementDaoFactory = new RequirementDaoFactory();
            this._requirementDao = RequirementDaoFactory.GetDaoInstance();
        }

        public void Update(Requirement Requirement)
        {
            if (Requirement == null)
                throw new ArgumentNullException();

            this._requirementDao.Update(Requirement);
        }

        public void Create(Requirement Requirement)
        {
            if (Requirement == null)
                throw new ArgumentNullException();

            this._requirementDao.Create(Requirement);
        }

        public IEnumerable<Requirement> GetAllRequirements()
        {
            return this._requirementDao.GetAll();
        }

        public Requirement GetRequirementByRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentNullException();

            return this._requirementDao.GetRequirementByRequirementNumber(RequirementNumber);
        }

        public IDictionary<Requirement.Attributes, string> GetValidationErrors(Requirement Requirement)
        {
            IDictionary<Requirement.Attributes, string> ErrorMessages = new Dictionary<Requirement.Attributes, string>();

            //Requirement number
            RequirementNumberValidator RequirementNumberValidator = new RequirementNumberValidator();
            RequirementNumberValidator.RequirementNumberToValidate = Requirement.RequirementNumber;
            RequirementNumberValidator.ErrorMessages = ErrorMessages;
            RequirementNumberValidator.Validate();

            //Purchase order
            PurchaseOrderValidator PurchaseOrderValidator = new PurchaseOrderValidator();
            PurchaseOrderValidator.PurchaseOrderToValidate = Requirement.PurchaseOrder;
            PurchaseOrderValidator.ErrorMessages = ErrorMessages;
            PurchaseOrderValidator.Validate();

            //Purchase order excercise
            PurchaseOrderExcerciseValidator PurchaseOrderExcerciseValidator = new PurchaseOrderExcerciseValidator();
            PurchaseOrderExcerciseValidator.PurchaseOrderExcerciseToValidate = Requirement.PurchaseOrderExcercise;
            PurchaseOrderExcerciseValidator.ErrorMessages = ErrorMessages;
            PurchaseOrderExcerciseValidator.Validate();

            //Certification days
            CertificationDaysValidator CertificationDaysValidator = new CertificationDaysValidator();
            CertificationDaysValidator.CertificationDaysToValidate = Requirement.CertificationDays;
            CertificationDaysValidator.ErrorMessages = ErrorMessages;
            CertificationDaysValidator.Validate();

            //Provider
            ProviderValidator ProviderValidator = new ProviderValidator();
            ProviderValidator.ProviderToValidate = Requirement.Provider;
            ProviderValidator.ErrorMessages = ErrorMessages;
            ProviderValidator.Validate();

            return ErrorMessages;
        }

        public void Delete(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentNullException();

            this._requirementDao.Delete(RequirementNumber);
        }
    }
}
