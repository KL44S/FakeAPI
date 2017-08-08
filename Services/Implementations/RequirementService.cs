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
using Exceptions;

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

        public IDictionary<Attributes.Requirement, string> GetValidationErrors(Requirement Requirement)
        {
            IDictionary<Attributes.Requirement, string> ErrorMessages = new Dictionary<Attributes.Requirement, string>();

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

            IItemService ItemService = new ItemService();
            ISheetService SheetService = new SheetService();
            IRequirementUserService RequirementUserService = new RequirementUserService();

            try
            {
                ItemService.DeleteAllByRequirementNumber(RequirementNumber);
                SheetService.DeleteAllByRequirementNumber(RequirementNumber);
                RequirementUserService.DeleteByRequirementNumber(RequirementNumber);

                this._requirementDao.Delete(RequirementNumber);
            }
            catch (EntityNotFoundException) { }       
        }

        public IEnumerable<Requirement> GetAllRequirementsByCuit(string Cuit)
        {
            RequirementUserDao RequirementUserDao = new RequirementUserDaoFactory().GetDaoInstance();

            IList<Requirement> Requirements = new List<Requirement>();
            IEnumerable<RequirementUser> RequirementUsers = RequirementUserDao.GetAllByCuit(Cuit);

            foreach (RequirementUser RequirementUser in RequirementUsers)
            {
                Requirement Requirement = this._requirementDao.GetRequirementByRequirementNumber(RequirementUser.RequirementNumber);
                Requirements.Add(Requirement);
            }

            return Requirements;
        }
    }
}
