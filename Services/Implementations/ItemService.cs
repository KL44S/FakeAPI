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
    public class ItemService : IItemService
    {
        private ItemDao _itemDao;

        public ItemService()
        {
            this._itemDao = (new ItemDaoFactory()).GetDaoInstance();
        }

        public void Create(Item Item)
        {
            if (Item == null)
                throw new ArgumentException();

            this._itemDao.Create(Item);
        }

        public void Delete(int RequirementNumber, int ItemNumber)
        {
            if (RequirementNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            ISubItemService SubItemService = new SubItemService();
            SubItemService.DeleteAllByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);

            this._itemDao.Delete(RequirementNumber, ItemNumber);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return this._itemDao.GetAll();
        }

        public IEnumerable<Item> GetItemsByRequirementNumber(int RequirementNumber)
        {
            if (RequirementNumber <= 0)
                throw new ArgumentException();

            IEnumerable<Item> Items = this._itemDao.GetAllByRequirementNumber(RequirementNumber);

            return Items;
        }

        public Item GetItemByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            if (RequirementNumber <= 0 || ItemNumber <= 0)
                throw new ArgumentException();

            Item Item = this._itemDao.GetByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);

            return Item;
        }

        public void Update(Item Item)
        {
            if (Item == null)
                throw new ArgumentException();

            this._itemDao.Update(Item);
        }

        public IDictionary<Item.Attributes, string> GetValidationErrors(Item Item)
        {
            IDictionary<Item.Attributes, string> ValidationErrors = new Dictionary<Item.Attributes, string>();

            NotExistingRequirementValidator NotExistingRequirementValidator = new NotExistingRequirementValidator();
            NotExistingRequirementValidator.ErrorMessages = ValidationErrors;
            NotExistingRequirementValidator.RequirementNumberToValidate = Item.RequirementNumber;
            NotExistingRequirementValidator.Validate();

            ItemDescriptionValidator ItemDescriptionValidator = new ItemDescriptionValidator();
            ItemDescriptionValidator.ErrorMessages = ValidationErrors;
            ItemDescriptionValidator.ItemDescription = Item.Description;
            NotExistingRequirementValidator.Validate();

            return ValidationErrors;
        }
    }
}
