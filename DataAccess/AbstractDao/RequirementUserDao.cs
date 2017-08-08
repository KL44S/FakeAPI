using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class RequirementUserDao : IDao<RequirementUser>
    {
        public abstract void Create(RequirementUser RequirementUser);
        public abstract IEnumerable<RequirementUser> GetAll();
        public abstract void Update(RequirementUser RequirementUser);
        public abstract IEnumerable<RequirementUser> GetAllByRequirementNumber(int RequirementNumber);
        public abstract IEnumerable<RequirementUser> GetAllByCuit(String Cuit);
        public abstract RequirementUser GetByCuitAndRequirementNumber(String Cuit, int RequirementNumber);
        public abstract void DeleteAllByRequirementNumber(int RequirementNumber);
    }
}
