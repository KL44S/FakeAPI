using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IRequirementService
    {
        IEnumerable<Requirement> GetAllRequirements();
        Requirement GetRequirementByRequirementNumber(int RequirementNumber);
        void Create(Requirement Requirement);
        IDictionary<Requirement.Attributes, String> GetValidationErrors(Requirement Requirement);
    }
}
