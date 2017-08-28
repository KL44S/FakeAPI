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
using Services.Validators.Abstractions;

namespace Services.Implementations
{
    public class SheetService : Observable, ISheetService, IObserver
    {
        private SheetDao _sheetDao;
        private MessageDao _messageDao;

        public SheetService() : base()
        {
            SheetDaoFactory SheetDaoFactory = new SheetDaoFactory();
            MessageDaoFactory MessageDaoFactory = new MessageDaoFactory();

            this._messageDao = MessageDaoFactory.GetDaoInstance();
            this._sheetDao = SheetDaoFactory.GetDaoInstance();
        }

        private int GetFirstStateId()
        {
            ParameterDaoFactory ParameterDaoFactory = new ParameterDaoFactory();
            ParameterDao ParameterDao = ParameterDaoFactory.GetDaoInstance();

            int FirstSheetStateId = int.Parse(ParameterDao.GetParameterById(Constants.FirstSheetStateIdParameter));

            return FirstSheetStateId;
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

        public String GetValidationErrorMessage(Sheet Sheet)
        {
            Sheet CurrentSheet = this.GetSheetByRequirementNumberAndSheetNumber(Sheet.RequirementNumber, Sheet.SheetNumber);
            String ErrorMessage = String.Empty;

            IList<IValidator> Validators = new List<IValidator>();

            SheetChangesValidator SheetChangesValidator = new SheetChangesValidator(CurrentSheet, Sheet);
            SheetStateChangeValidator SheetStateChangeValidator = new SheetStateChangeValidator(CurrentSheet.SheetStateId, Sheet.SheetStateId);

            Validators.Add(SheetChangesValidator);
            Validators.Add(SheetStateChangeValidator);

            Boolean ValidationSuccessful = true;
            int i = 0;

            while (i < Validators.Count() && ValidationSuccessful)
            {
                ValidationSuccessful = Validators.ElementAt(i).Validate();
                i++;
            }

            if (!ValidationSuccessful)
            {
                ErrorMessage = this._messageDao.GetById(Constants.NoActionAllowedErrorMessage);
            }

            return ErrorMessage;
        }

        public void UpdateSheet(Sheet Sheet)
        {
            this._sheetDao.Update(Sheet);
            this.NotifyObservers(Sheet);
        }

        public void DeleteAllByRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentException();

            IEnumerable<Sheet> Sheets = this.GetAllSheetsFromRequirement(RequirementNumber);

            foreach (Sheet Sheet in Sheets)
            {
                //TODO: eliminar item sheets
                this._sheetDao.Delete(RequirementNumber, Sheet.SheetNumber);
            }
        }

        public Boolean IsSheetTheCurrentSheet(Sheet Sheet)
        {
            Sheet CurrentSheet = this._sheetDao.GetCurrentSheetByRequirementNumber(Sheet.RequirementNumber);

            return (CurrentSheet.SheetNumber.Equals(Sheet.SheetNumber));
        }

        public bool MayUserUpdateSheet(string UserCuit, Sheet Sheet)
        {
            UserSheetStateChangeValidator UserSheetStateChangeValidator = new UserSheetStateChangeValidator(Sheet.SheetStateId, UserCuit);

            return UserSheetStateChangeValidator.Validate();
        }

        private Boolean CreateFirstSheetIfItIsNeccesary(Requirement Requirement)
        {
            IEnumerable<Sheet> Sheets = this._sheetDao.GetAllByRequirementNumber(Requirement.RequirementNumber);

            if (Sheets.Count().Equals(0) && Requirement.InitDate != null)
            {
                DateTime NewFromDate = (DateTime)Requirement.InitDate;
                DateTime NewUntilDate = NewFromDate.AddDays(Requirement.CertificationDays);
                int FirsSheetNumber = 1;

                Sheet Sheet = new Sheet();
                Sheet.RequirementNumber = Requirement.RequirementNumber;
                Sheet.SheetNumber = FirsSheetNumber;
                Sheet.SheetStateId = this.GetFirstStateId();
                Sheet.FromDate = NewFromDate;
                Sheet.UntilDate = NewUntilDate;

                this._sheetDao.Create(Sheet);

                return true;
            }

            return false;
        }

        private void UpdateSheets(Requirement Requirement)
        {
            ParameterDao ParameterDao = (new ParameterDaoFactory()).GetDaoInstance();
            int FinalStateSheetId = int.Parse(ParameterDao.GetParameterById(Constants.FinalSheetStateIdParameter));

            IEnumerable<Sheet> Sheets = this._sheetDao.GetAllByRequirementNumber(Requirement.RequirementNumber);
            DateTime LastUntilDate = DateTime.Now;
            int i = 0;
            Boolean MustKeepProcessing = true;

            while (i < Sheets.Count() && MustKeepProcessing)
            {
                Sheet Sheet = Sheets.ElementAt(i);

                if (i != 0)
                {
                    if (!Sheet.SheetStateId.Equals(FinalStateSheetId))
                    {
                        Sheet.FromDate = LastUntilDate.AddDays(1);
                        Sheet.UntilDate = Sheet.FromDate.AddDays(Requirement.CertificationDays);
                        this._sheetDao.Update(Sheet);
                    }

                    LastUntilDate = Sheet.UntilDate;
                }
                else
                {
                    int DifferenceDays = (Sheet.UntilDate - Sheet.FromDate).Days;

                    if (DifferenceDays.Equals(Requirement.CertificationDays))
                    {
                        MustKeepProcessing = false;
                    }
                    else
                    {
                        if (!Sheet.SheetStateId.Equals(FinalStateSheetId))
                        {
                            Sheet.UntilDate = Sheet.FromDate.AddDays(Requirement.CertificationDays);
                            this._sheetDao.Update(Sheet);
                        }

                        LastUntilDate = Sheet.UntilDate;
                    }
                }

                i++;
            }
        }

        public void IhaveBeenChanged(object InvokingObject, object Params)
        {
            Requirement Requirement = (Requirement)Params;

            if (!this.CreateFirstSheetIfItIsNeccesary(Requirement))
            {
                this.UpdateSheets(Requirement);
            }

        }

        public void IhaveBeenChanged(object InvokingObject)
        {
            throw new NotImplementedException();
        }
    }
}
