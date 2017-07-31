using DataAccess.AbstractDao;
using DataAccess.Factories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public abstract class ExpirationStateService
    {
        protected static int _warningDaysBeforeExpiration = 5;
        protected int _expirationStateId;
        public ExpirationStateService NextExpirationStateService { get; set; }
        protected ExpirationStateDao _expirationStateDao;

        public ExpirationStateService()
        {
            ExpirationStateDaoFactory ExpirationStateDaoFactory = new ExpirationStateDaoFactory();
            this._expirationStateDao = ExpirationStateDaoFactory.GetDaoInstance();
        }

        protected abstract Boolean MustIPerform(int RemainingDays);

        public ExpirationState GetExpirationStateFromSheet(Sheet Sheet)
        {
            DateTime Now = DateTime.Now;
            DateTime ExpirationDate = Sheet.UntilDate;
            
            int RemainingDays = (ExpirationDate - Now).Days;
            ExpirationState ExpirationState = null;

            if (this.MustIPerform(RemainingDays))
            {
                ExpirationState = this._expirationStateDao.GetById(this._expirationStateId);
            }
            else
            {
                ExpirationState = this.NextExpirationStateService.GetExpirationStateFromSheet(Sheet);
            }

            return ExpirationState;
        }
    }
}
