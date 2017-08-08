using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class RequirementMemoryDao : RequirementDao
    {
        private static IList<Requirement> _requirements = new List<Requirement>()
        {
            new Requirement()
            {
                RequirementNumber = 1556,
                PurchaseOrder = 143,
                PurchaseOrderExcercise = 2015,
                Provider = "COTO CISCA - 15464 - SA",
                CertificationDays = 30
            },
            new Requirement()
            {
                RequirementNumber = 1557,
                PurchaseOrder = 143,
                PurchaseOrderExcercise = 2015,
                Provider = "PANTENE - 15464 - SA",
                CertificationDays = 30
            },
            new Requirement()
            {
                RequirementNumber = 1558,
                PurchaseOrder = 142,
                PurchaseOrderExcercise = 2016,
                Provider = "SOMEONE - 15464 - SA",
                CertificationDays = 30
            }
        };

        public override void Create(Requirement Requirement)
        {
            _requirements.Add(Requirement);
        }

        public override void Delete(int RequirementNumber)
        {
            Requirement Requirement = this.GetRequirementByRequirementNumber(RequirementNumber);
            _requirements.Remove(Requirement);
            var ala = _requirements.ToList();
        }

        public override IEnumerable<Requirement> GetAll()
        {
            return _requirements;
        }

        public override Requirement GetRequirementByRequirementNumber(int RequirementNumber)
        {
            Requirement FoundRequirement = _requirements.FirstOrDefault(Requirement => Requirement.RequirementNumber.Equals(RequirementNumber));

            if (FoundRequirement != null)
                return FoundRequirement;

            throw new EntityNotFoundException();
        }

        public override void Update(Requirement Requirement)
        {
            Requirement FoundRequirement = this.GetRequirementByRequirementNumber(Requirement.RequirementNumber);
            FoundRequirement.Provider = Requirement.Provider;
            FoundRequirement.PurchaseOrder = Requirement.PurchaseOrder;
            FoundRequirement.PurchaseOrderExcercise = Requirement.PurchaseOrderExcercise;
            FoundRequirement.CertificationDays = Requirement.CertificationDays;
        }
    }
}
