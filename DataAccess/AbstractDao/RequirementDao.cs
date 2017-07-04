using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class RequirementDao : IDao<Requirement>
    {
        public abstract void Create(Requirement Requirement);
        public abstract IEnumerable<Requirement> GetAll();
        public abstract void Update(Requirement Requirement);
        public abstract Requirement GetRequirementByRequirementNumber(int RequirementNumber);
    }
}
