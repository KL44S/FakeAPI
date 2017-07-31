using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ActiveStateService : ExpirationStateService
    {
        public ActiveStateService() : base()
        {
            //Active state id
            this._expirationStateId = 1;
        }

        protected override bool MustIPerform(int RemainingDays)
        {
            return (RemainingDays > _warningDaysBeforeExpiration);
        }
    }
}
