using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.Mapping;
using DataAccess.SqlServerDao.EntityModel;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class SheetStateSqlServerDao : SheetStateDao
    {
        private SheetStateMapping _sheetStateMapping;

        public SheetStateSqlServerDao()
        {
            this._sheetStateMapping = new SheetStateMapping();
        }

        public override void Create(Model.SheetState SheetState)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Model.SheetState> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<Model.SheetState> SheetStates = this._sheetStateMapping.UnMapEntities(ObrasEntities.SheetState);

                if (SheetStates != null)
                    return SheetStates;

                throw new EntityNotFoundException();
            }
        }

        public override Model.SheetState GetSheetState(int SheetStateId)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.SheetState SheetState = ObrasEntities.SheetState.FirstOrDefault(SState => SState.sheetStateId.Equals(SheetStateId));

                if (SheetState == null)
                    throw new EntityNotFoundException();

                Model.SheetState ModelSheetState = this._sheetStateMapping.UnMapEntity(SheetState);

                return ModelSheetState;
            }
        }

        public override void Update(Model.SheetState SheetState)
        {
            throw new NotImplementedException();
        }
    }
}
