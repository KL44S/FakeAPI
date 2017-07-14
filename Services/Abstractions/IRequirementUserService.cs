using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IRequirementUserService
    {
        IEnumerable<User> GetUsersFromRequirementNumber(int RequirementNumber);
        void SaveRequirementUser(RequirementUser RequirementUser);
    }
}
