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

        public void Create(Requirement Requirement)
        {
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
            MessageDao MessageDao = new MessageMemoryDao();
            

        }
    }
}
