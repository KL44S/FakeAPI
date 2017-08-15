using Services.Abstractions;
using Services.Implementations;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Services.Validators.Implementations
{
    public class UserSheetStateChangeValidator : IValidator
    {
        public String _userCuitToValidate { get; set; }
        public int _newSheetStateIdToValidate;

        public UserSheetStateChangeValidator(int NewSheetStateIdToValidate, String UserCuitToValidate)
        {
            this._newSheetStateIdToValidate = NewSheetStateIdToValidate;
            this._userCuitToValidate = UserCuitToValidate;
        }

        private static IDictionary<int, int> _actionsByStateSheetChange = new Dictionary<int, int>
        {
            { Constants.EnteredSheetStateId, Constants.EnterSheetAction },
            { Constants.ApprovedSheetStateId, Constants.ApproveSheetAction },
            { Constants.ObservedSheetStateId, Constants.ObserveSheetAction },
            { Constants.RejectEnterSheetStateId, Constants.RejectSheetAction }
        };

        public bool Validate()
        {
            if (String.IsNullOrEmpty(this._userCuitToValidate) || this._newSheetStateIdToValidate <= 0)
                throw new ArgumentException();

            if (_actionsByStateSheetChange.ContainsKey(this._newSheetStateIdToValidate))
            {
                int ActionToValidate = _actionsByStateSheetChange[this._newSheetStateIdToValidate];
                IRoleActionService RoleActionService = new RoleActionService();
                IUserService UserService = new UserService();

                User User = UserService.GetUserByCuit(this._userCuitToValidate);
                IEnumerable<int> Actions = RoleActionService.GetAllActionsFromUser(User);

                Boolean UserHasAction = Actions.Contains(ActionToValidate);

                if (UserHasAction)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else throw new EntityNotFoundException();

        }
    }
}
