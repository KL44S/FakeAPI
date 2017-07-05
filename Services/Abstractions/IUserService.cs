using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IUserService
    {
        User GetUserByCuitAndPassword(String Cuit, String Password);
        User GetUserByCuit(String Cuit);
        IEnumerable<User> GetUsersByRoleId(int RoleId);
        IEnumerable<User> GetUsersByRequirementNumber(int RequirementNumber);
        IEnumerable<User> GetUsersByRoleIdAndRequirementNumber(int RoleId, int RequirementNumber);
        IEnumerable<User> GetAllUsers();
    }
}
