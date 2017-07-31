using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ExpiredStateService : ExpirationStateService
    {
        public ExpiredStateService() : base()
        {
            //Expired state id
            this._expirationStateId = 3;
        }

        protected override bool MustIPerform(int RemainingDays)
        {
            return (RemainingDays < 0);
        }
    }
}
