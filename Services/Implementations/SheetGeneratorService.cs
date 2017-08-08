using Services.Abstractions;
using System;
using Model;
using DataAccess.AbstractDao;
using DataAccess.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class SheetGeneratorService : IObserver
    {
        private int GetFinalStateId()
        {
            ParameterDaoFactory ParameterDaoFactory = new ParameterDaoFactory();
            ParameterDao ParameterDao = ParameterDaoFactory.GetDaoInstance();

            int FinalSheetStateId = int.Parse(ParameterDao.GetParameterById(Constants.FinalSheetStateIdParameter));

            return FinalSheetStateId;
        }

        private Boolean MustAnewSheetBeGenerated(Sheet Sheet)
        {
            return (Sheet.SheetStateId.Equals(this.GetFinalStateId()));
        }

        public void IhaveBeenChanged(object InvokingObject)
        {
            throw new NotImplementedException();
        }

        public void IhaveBeenChanged(object InvokingObject, object Params)
        {
            Sheet Sheet = (Sheet)Params;
            ISheetService SheetService = (ISheetService)InvokingObject;

            if (this.MustAnewSheetBeGenerated(Sheet))
            {
                SheetService.GenerateSheet(Sheet.RequirementNumber);
            }
        }
    }
}
