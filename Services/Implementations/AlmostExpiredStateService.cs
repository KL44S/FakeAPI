using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AlmostExpiredStateService : ExpirationStateService
    {
        public AlmostExpiredStateService() : base()
        {
            //Almost Expired state id
            this._expirationStateId = 2;
        }

        protected override bool MustIPerform(int RemainingDays)
        {
            return (RemainingDays <= _warningDaysBeforeExpiration);
        }
    }
}
