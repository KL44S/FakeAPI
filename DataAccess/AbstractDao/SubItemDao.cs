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
        public abstract void Update(SubItem SubItem);
    }
}
