using DataAccess.AbstractDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Exceptions;

namespace DataAccess.MemoryDao
{
    public class SheetMemoryDao : SheetDao
    {
        private static IList<Sheet> _sheets = new List<Sheet>()
        {
            new Sheet()
            {
                SheetNumber = 1,
                RequirementNumber = 1556,
                SheetStateId = 3,
                FromDate = DateTime.Now,
                UntilDate = DateTime.Now.AddDays(30)
            }
        };

        private int GenerateAndGetNewSheetNumberFromRequirement(int RequirementNumber)
        {
            try
            {
                Sheet CurrentSheet = this.GetCurrentSheetByRequirementNumber(RequirementNumber);
                int NewSheetNumber = CurrentSheet.SheetNumber + 1;

                return NewSheetNumber;
            }
            catch (EntityNotFoundException)
            {
                return 1;
            }
        }

        public override void Create(Sheet Sheet)
        {
            Sheet.SheetNumber = this.GenerateAndGetNewSheetNumberFromRequirement(Sheet.RequirementNumber);

            _sheets.Add(Sheet);
        }

        public override IEnumerable<Sheet> GetAll()
        {
            return _sheets;
        }

        public override IEnumerable<Sheet> GetAllByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<Sheet> Sheets = _sheets.Where(Sheet => Sheet.RequirementNumber.Equals(RequirementNumber)).ToList();

            if (Sheets != null)
                return Sheets;

            throw new EntityNotFoundException();
        }

        public override void Update(Sheet Sheet)
        {
            Sheet CurrentSheet = this.GetSheetByRequirementNumberAndSheetNumber(Sheet.RequirementNumber, Sheet.SheetNumber);
            CurrentSheet.FromDate = Sheet.FromDate;
            CurrentSheet.UntilDate = Sheet.UntilDate;
            CurrentSheet.SheetStateId = Sheet.SheetStateId;
        }

        public override Sheet GetSheetByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber)
        {
            Sheet Sheet = _sheets.FirstOrDefault(ASheet => ASheet.RequirementNumber.Equals(RequirementNumber) && ASheet.SheetNumber.Equals(SheetNumber));

            if (Sheet != null)
                return Sheet;

            throw new EntityNotFoundException();
        }

        public override Sheet GetCurrentSheetByRequirementNumber(int RequirementNumber)
        {
            Sheet Sheet = _sheets.Where(ASheet => ASheet.RequirementNumber.Equals(RequirementNumber))
                                            .OrderByDescending(ASheet => ASheet.SheetNumber).FirstOrDefault();

            if (Sheet != null)
                return Sheet;

            throw new EntityNotFoundException();
        }

        public override void Delete(int RequirementNumber, int SheetNumber)
        {
            List<Sheet> Sheets = _sheets.ToList();
            Sheets.RemoveAll(Sheet => Sheet.RequirementNumber.Equals(RequirementNumber) && Sheet.SheetNumber.Equals(SheetNumber));
            _sheets = Sheets;
        }

    }
}
