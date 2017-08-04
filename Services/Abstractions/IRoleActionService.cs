using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IRoleActionService
    {
        Boolean HasUserAction(User User, int ActionId);
        IEnumerable<int> GetAllActionsFromUser(User User);
    }
}
