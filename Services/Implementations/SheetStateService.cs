using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;

namespace Services.Implementations
{
    public class SheetStateService : ISheetStateService
    {
        private SheetStateDao _sheetStateDao;

        public SheetStateService()
        {
            SheetStateDaoFactory SheetStateDaoFactory = new SheetStateDaoFactory();
            this._sheetStateDao = SheetStateDaoFactory.GetDaoInstance();
        }

        private SheetDao GetSheetDao()
        {
            SheetDaoFactory SheetDaoFactory = new SheetDaoFactory();
            SheetDao SheetDao = SheetDaoFactory.GetDaoInstance();

            return SheetDao;
        }

        public SheetState GetSheetStateByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            if (RequirementNumber <= 0 || SheetNumber <= 0)
                throw new ArgumentException();

            SheetDao SheetDao = this.GetSheetDao();
            Sheet Sheet = SheetDao.GetSheetByRequirementNumberAndSheetNumber(RequirementNumber, SheetNumber);
            SheetState SheetState = this._sheetStateDao.GetSheetState(Sheet.SheetStateId);

            return SheetState;
        }

        public IEnumerable<SheetState> GetSheetStates()
        {
            IEnumerable<SheetState> SheetStates = this._sheetStateDao.GetAll();

            return SheetStates;
        }

        public SheetState GetSheetStateById(int SheetStateId)
        {
            if (SheetStateId <= 0)
                throw new ArgumentException();

            SheetState SheetState = this._sheetStateDao.GetSheetState(SheetStateId);

            return SheetState;
        }
    }
}
