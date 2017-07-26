using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ISubItemService
    {
        IEnumerable<SubItem> GetSubItemsByRequirementNumber(int RequirementNumber);
        IEnumerable<SubItem> GetSubItemsByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        void Create(SubItem SubItem);
        void Update(SubItem SubItem);
        void Delete(int RequirementNumber, int ItemNumber, int SubItemNumber);
        IDictionary<Attributes.SubItem, String> GetValidationErrors(SubItem SubItem);
        void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
    }
}
