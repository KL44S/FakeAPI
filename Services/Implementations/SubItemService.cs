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
    public class SubItemService : ISubItemService
    {
        private SubItemDao _subItemDao;

        public SubItemService()
        {
            this._subItemDao = (new SubItemDaoFactory()).GetDaoInstance();
        }

        public void Create(SubItem SubItem)
        {
            if (SubItem == null)
                throw new ArgumentException();

            this._subItemDao.Create(SubItem);
        }

        public void Delete(int RequirementNumber, int ItemNumber, int SubItemNumber)
        {
            if (RequirementNumber <= 0 || ItemNumber <= 0 || SubItemNumber <= 0)
                throw new ArgumentException();

            this._subItemDao.Delete(RequirementNumber, ItemNumber, SubItemNumber);
        }

        public void DeleteAllByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            if (RequirementNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            this._subItemDao.DeleteAllByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);
        }

        public IEnumerable<SubItem> GetSubItemsByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<SubItem> SubItems = this._subItemDao.GetSubItemsByRequirementNumber(RequirementNumber);

            return SubItems;
        }

        public IEnumerable<SubItem> GetSubItemsByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            IEnumerable<SubItem> SubItems = this._subItemDao.GetAllByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);

            return SubItems;
        }

        public IDictionary<SubItem.Attributes, string> GetValidationErrors(SubItem SubItem)
        {
            throw new NotImplementedException();
        }

        public void Update(SubItem SubItem)
        {
            if (SubItem == null)
                throw new ArgumentException();

            this._subItemDao.Update(SubItem);
        }
    }
}
