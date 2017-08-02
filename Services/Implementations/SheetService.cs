using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using Services.Validators.Implementations;
using DataAccess;

namespace Services.Implementations
{
    public class SheetService : ISheetService
    {
        private SheetDao _sheetDao;

        public SheetService()
        {
            SheetDaoFactory SheetDaoFactory = new SheetDaoFactory();

            this._sheetDao = SheetDaoFactory.GetDaoInstance();
        }

        private int GetFirstStateId()
        {
            ParameterDaoFactory ParameterDaoFactory = new ParameterDaoFactory();
            ParameterDao ParameterDao = ParameterDaoFactory.GetDaoInstance();

            int FirstSheetStateId = int.Parse(ParameterDao.GetParameterById(Constants.FirstSheetStateIdParameter));

            return FirstSheetStateId;
        }

        private int GetFinalStateId()
        {
            ParameterDaoFactory ParameterDaoFactory = new ParameterDaoFactory();
            ParameterDao ParameterDao = ParameterDaoFactory.GetDaoInstance();

            int FinalSheetStateId = int.Parse(ParameterDao.GetParameterById(Constants.FinalSheetStateIdParameter));

            return FinalSheetStateId;
        }

        private Sheet GenerateAndGetNewSheet(Sheet CurrentSheet, int DaysOfCertification)
        {
            DateTime NewFromDate = CurrentSheet.UntilDate.AddDays(1);
            DateTime NewUntilDate = NewFromDate.AddDays(DaysOfCertification);

            Sheet NewSheet = new Sheet();
            NewSheet.SheetStateId = this.GetFirstStateId();
            NewSheet.RequirementNumber = CurrentSheet.RequirementNumber;
            NewSheet.FromDate = NewFromDate;
            NewSheet.UntilDate = NewUntilDate;

            return NewSheet;
        }

        private Requirement GetRequirement(int RequirementNumber)
        {
            RequirementService RequirementService = new RequirementService();
            Requirement Requirement = RequirementService.GetRequirementByRequirementNumber(RequirementNumber);

            return Requirement;
        }

        private void GenerateSheetItemsFromSheet(Sheet Sheet)
        {
            ISheetItemService SheetItemService = new SheetItemService();
            SheetItemService.GenerateSheetItemsFromSheet(Sheet);
        }

        public void GenerateSheet(int RequirementNumber)
        {
            Sheet CurrentSheet = this._sheetDao.GetCurrentSheetByRequirementNumber(RequirementNumber);
            Requirement Requirement = this.GetRequirement(RequirementNumber);
            int DaysOfCertification = Requirement.CertificationDays;

            Sheet NewSheet = this.GenerateAndGetNewSheet(CurrentSheet, DaysOfCertification);
            this._sheetDao.Create(NewSheet);

            this.GenerateSheetItemsFromSheet(NewSheet);
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
        
        public ExpirationState GetExpirationStateFromSheet(Sheet Sheet)
        {
            ExpirationStateService AlmostExpiredStateService = new AlmostExpiredStateService();

            ExpirationStateService ActiveStateService = new ActiveStateService();
            ActiveStateService.NextExpirationStateService = AlmostExpiredStateService;

            ExpirationStateService ExpiredStateService = new ExpiredStateService();
            ExpiredStateService.NextExpirationStateService = ActiveStateService;

            ExpirationStateService ExpirationStateService = ExpiredStateService;

            ExpirationState ExpirationState = ExpirationStateService.GetExpirationStateFromSheet(Sheet);
            return ExpirationState;
        }

        public void UpdateSheet(Sheet Sheet)
        {
            Sheet CurrentSheet = this.GetSheetByRequirementNumberAndSheetNumber(Sheet.RequirementNumber, Sheet.SheetNumber);
            SheetChangesValidator SheetChangesValidator = new SheetChangesValidator(CurrentSheet, Sheet);

            if (!SheetChangesValidator.Validate())
                throw new ArgumentException();

            this._sheetDao.Update(Sheet);

            if (Sheet.SheetStateId.Equals(this.GetFinalStateId()))
            {
                this.GenerateSheet(Sheet.RequirementNumber);
            }
        }

    }
}
