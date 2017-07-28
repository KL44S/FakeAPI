using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using DataAccess;

namespace Services.Implementations
{
    public class SheetService : ISheetService
    {
        private SheetDao _sheetDao;
        private static int _enteredStateId = 1;
        private static int _warningDaysBeforeExpiration = 5;
        private static int _expiredStateId = 3;
        private static int _almostExpiredId = 2;
        private static int _activeStateId = 1;

        public SheetService()
        {
            SheetDaoFactory SheetDaoFactory = new SheetDaoFactory();

            this._sheetDao = SheetDaoFactory.GetDaoInstance();
        }

        private Sheet GenerateAndGetNewSheet(Sheet CurrentSheet, int DaysOfCertification)
        {
            DateTime NewFromDate = CurrentSheet.UntilDate.AddDays(1);
            DateTime NewUntilDate = NewFromDate.AddDays(DaysOfCertification);

            Sheet NewSheet = new Sheet();
            NewSheet.SheetStateId = _enteredStateId;
            NewSheet.RequirementNumber = CurrentSheet.RequirementNumber;
            NewSheet.FromDate = NewFromDate;
            NewSheet.UntilDate = NewUntilDate;

            return NewSheet;
        }

        private Requirement GetRequirement(int RequirementNumber)
        {
            RequirementDaoFactory RequirementDaoFactory = new RequirementDaoFactory();
            RequirementDao RequirementDao = RequirementDaoFactory.GetDaoInstance();

            Requirement Requirement = RequirementDao.GetRequirementByRequirementNumber(RequirementNumber);

            return Requirement;
        }

        public void GenerateSheet(int RequirementNumber)
        {
            Sheet CurrentSheet = this._sheetDao.GetCurrentSheetByRequirementNumber(RequirementNumber);
            Requirement Requirement = this.GetRequirement(RequirementNumber);
            int DaysOfCertification = Requirement.CertificationDays;

            Sheet NewSheet = this.GenerateAndGetNewSheet(CurrentSheet, DaysOfCertification);
            this._sheetDao.Create(NewSheet);

            //TODO: generar los items
        }

        public IEnumerable<Sheet> GetAllSheetsFromRequirement(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentException();

            IEnumerable<Sheet> Sheets = this._sheetDao.GetAllByRequirementNumber(RequirementNumber);

            return Sheets;
        }

        public Sheet GetSheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            if (RequirementNumber <= 0 || SheetNumber <= 0)
                throw new ArgumentException();

            Sheet Sheet = this._sheetDao.GetSheetByRequirementNumberAndSheetNumber(RequirementNumber, SheetNumber);

            return Sheet;
        }

        private ExpirationStateDao GetExpirationStateDao()
        {
            ExpirationStateDaoFactory ExpirationStateDaoFactory = new ExpirationStateDaoFactory();
            ExpirationStateDao ExpirationStateDao = ExpirationStateDaoFactory.GetDaoInstance();

            return ExpirationStateDao;
        }

        public ExpirationState GetExpirationStateFromSheet(Sheet Sheet)
        {
            DateTime Now = DateTime.Now;
            DateTime ExpirationDate = Sheet.UntilDate;
            ExpirationStateDao ExpirationStateDao = this.GetExpirationStateDao();

            int RemainingDays = (ExpirationDate - Now).Days;
            ExpirationState ExpirationState = null;


            if (RemainingDays < 0)
            {
                ExpirationState = ExpirationStateDao.GetById(_expiredStateId);
            }
            else
            {
                if (RemainingDays > _warningDaysBeforeExpiration)
                {
                    ExpirationState = ExpirationStateDao.GetById(_activeStateId);
                }
                else
                {
                    ExpirationState = ExpirationStateDao.GetById(_almostExpiredId);
                }
            }

            return ExpirationState;
        }
    }
}
