using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class SubItemDao : IDao<SubItem>
    {
        public abstract void Create(SubItem SubItem);
        public abstract IEnumerable<SubItem> GetAll();
        public abstract IEnumerable<SubItem> GetAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        public abstract IEnumerable<SubItem> GetSubItemsByRequirementNumber(int RequirementNumber);
        public abstract SubItem GetSubItemByRequirementNumberAndItemNumberAndSubItemNumber(int RequirementNumber, int ItemNumber, int SubItemNumber);
        public abstract void Update(SubItem SubItem);
        public abstract void Delete(int RequirementNumber, int ItemNumber, int SubItemNumber);
        public abstract void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
    }
}
