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
    public class SheetSqlServerDao : SheetDao
    {
        private SheetMapping _sheetMapping;

        public SheetSqlServerDao()
        {
            this._sheetMapping = new SheetMapping();
        }

        private int GenerateAndGetNewSheetNumberFromRequirement(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                try
                {
                    EntityModel.Sheet LastSheet = this.GetCurrentEntitySheetByRequirementNumber(RequirementNumber);
                    int NewSheetNumber = LastSheet.sheetNumber + 1;

                    return NewSheetNumber;
                }
                catch (EntityNotFoundException)
                {
                    return 1;
                }
            }
        }

        public override void Create(Model.Sheet Sheet)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet EntitySheet = this._sheetMapping.MapModel(Sheet);
                EntitySheet.sheetNumber = this.GenerateAndGetNewSheetNumberFromRequirement(EntitySheet.requirementNumber);

                ObrasEntities.Sheet.Add(EntitySheet);
            }
        }

        public override IEnumerable<Model.Sheet> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.Sheet> EntitySheets = ObrasEntities.Sheet.ToList();
                IEnumerable<Model.Sheet> Sheets = this._sheetMapping.UnMapEntities(EntitySheets);

                return Sheets;
            }
        }

        public override IEnumerable<Model.Sheet> GetAllByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<EntityModel.Sheet> EntitySheets = ObrasEntities.Sheet.Where(Sheet => Sheet.requirementNumber.Equals(RequirementNumber));

                if (EntitySheets == null)
                    throw new EntityNotFoundException();

                IEnumerable<Model.Sheet> Sheets = this._sheetMapping.UnMapEntities(EntitySheets);

                return Sheets;
            }
        }

        private EntityModel.Sheet GetCurrentEntitySheetByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet LastSheet = ObrasEntities.Sheet.Where(ESheet => ESheet.requirementNumber.Equals(RequirementNumber)).OrderBy(ESheet => ESheet.sheetNumber)
                                        .FirstOrDefault();

                if (LastSheet == null)
                    throw new EntityNotFoundException();

                return LastSheet;
            }
        }

        public override Model.Sheet GetCurrentSheetByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet LastSheet = this.GetCurrentEntitySheetByRequirementNumber(RequirementNumber);

                Model.Sheet Sheet = this._sheetMapping.UnMapEntity(LastSheet);

                return Sheet;
            }
        }

        private EntityModel.Sheet GetEntitySheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet EntitySheet = ObrasEntities.Sheet.FirstOrDefault(Sheet => Sheet.requirementNumber.Equals(RequirementNumber)
                                                    && Sheet.sheetNumber.Equals(SheetNumber));

                if (EntitySheet == null)
                    throw new EntityNotFoundException();

                return EntitySheet;
            }
        }

        public override Model.Sheet GetSheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet EntitySheet = this.GetEntitySheetByRequirementNumberAndSheetNumber(RequirementNumber, SheetNumber);
                Model.Sheet ModelSheet = this._sheetMapping.UnMapEntity(EntitySheet);

                return ModelSheet;
            }
        }

        public override void Update(Model.Sheet Sheet)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet EntitySheet = this.GetEntitySheetByRequirementNumberAndSheetNumber(Sheet.RequirementNumber, Sheet.SheetNumber);
                this._sheetMapping.MapModel(Sheet, EntitySheet);

                ObrasEntities.SaveChanges();
            }
        }

        public override void Delete(int RequirementNumber, int SheetNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Sheet Sheet = ObrasEntities.Sheet.FirstOrDefault(Sh => Sh.requirementNumber.Equals(RequirementNumber) 
                                                                                && Sh.sheetNumber.Equals(SheetNumber));

                if (Sheet == null)
                    throw new EntityNotFoundException();

                ObrasEntities.Sheet.Remove(Sheet);
                ObrasEntities.SaveChanges();
            }
        }
    }
}
