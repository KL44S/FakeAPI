using DataAccess.AbstractDao;
using DataAccess.Factories;
using Model;
using Services.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Implementations
{
    public class ExistingItemValidator : IValidator
    {
        public int RequirementNumberToValidate { get; set; }
        public int ItemNumberToValidate { get; set; }
        private ItemDao _itemDao;

        public ExistingItemValidator()
        {
            ItemDaoFactory ItemtDaoFactory = new ItemDaoFactory();
            this._itemDao = ItemtDaoFactory.GetDaoInstance();
        }

        public bool Validate()
        {
            if (this.RequirementNumberToValidate <= 0 || this.ItemNumberToValidate <= 0)
                throw new ArgumentNullException();

            this._itemDao.GetByRequirementNumberAndItemNumber(this.RequirementNumberToValidate, this.ItemNumberToValidate);
            return true;
        }
    }
}
