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

        public IDictionary<Attributes.SubItem, string> GetValidationErrors(SubItem SubItem)
        {
            IDictionary<Attributes.SubItem, String> ValidationErrors = new Dictionary<Attributes.SubItem, String>();

            ExistingItemValidator ExistingItemValidator = new ExistingItemValidator();
            ExistingItemValidator.RequirementNumberToValidate = SubItem.RequirementNumber;
            ExistingItemValidator.ItemNumberToValidate = SubItem.ItemNumber;
            ExistingItemValidator.Validate();

            SubItemDescriptionValidator SubItemDescriptionValidator = new SubItemDescriptionValidator();
            SubItemDescriptionValidator.SubItemDescription = SubItem.Description;
            SubItemDescriptionValidator.ErrorMessages = ValidationErrors;
            SubItemDescriptionValidator.Validate();

            UnitPriceValidator UnitPriceValidator = new UnitPriceValidator();
            UnitPriceValidator.UnitPriceToValidate = SubItem.UnitPrice;
            UnitPriceValidator.ErrorMessages = ValidationErrors;
            UnitPriceValidator.Validate();

            UnitOfMeasurementValidator UnitOfMeasurementValidator = new UnitOfMeasurementValidator();
            UnitOfMeasurementValidator.UnitOfMeasurementToValidate = SubItem.UnitOfMeasurement;
            UnitOfMeasurementValidator.ErrorMessages = ValidationErrors;
            UnitOfMeasurementValidator.Validate();

            TotalQuantityValidator TotalQuantityValidator = new TotalQuantityValidator();
            TotalQuantityValidator.TotalQuantityToValidate = SubItem.TotalQuantity;
            TotalQuantityValidator.ErrorMessages = ValidationErrors;
            TotalQuantityValidator.Validate();

            return ValidationErrors;
        }

        public void Update(SubItem SubItem)
        {
            if (SubItem == null)
                throw new ArgumentException();

            SubItem ExistingSubItem = this._subItemDao.GetSubItemByRequirementNumberAndItemNumberAndSubItemNumber(SubItem.RequirementNumber,
                                                                                                         SubItem.ItemNumber, SubItem.SubItemNumber);

            ExistingSubItem.Description = SubItem.Description;
            ExistingSubItem.Sis = SubItem.Sis;
            ExistingSubItem.TotalQuantity = SubItem.TotalQuantity;
            ExistingSubItem.UnitOfMeasurement = SubItem.UnitOfMeasurement;
            ExistingSubItem.UnitPrice = SubItem.UnitPrice;

            this._subItemDao.Update(ExistingSubItem);
        }
    }
}
