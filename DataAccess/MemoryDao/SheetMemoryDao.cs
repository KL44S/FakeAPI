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
                SheetStateId = 1,
                FromDate = DateTime.Now,
                UntilDate = DateTime.Now.AddMonths(1)
            }
        };

        public override void Create(Sheet Sheet)
        {
            _sheets.Add(Sheet);
        }

        public override IEnumerable<Sheet> GetAll()
        {
            return _sheets;
        }

        public override IEnumerable<Sheet> GetAllByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<Sheet> Sheets = _sheets.Where(Sheet => Sheet.RequirementNumber.Equals(RequirementNumber));

            if (Sheets != null && Sheets.Count() > 0)
                return Sheets;

            throw new EntityNotFoundException();
        }

        public override void Update(Sheet Sheet)
        {
            throw new NotImplementedException();
        }
    }
}
