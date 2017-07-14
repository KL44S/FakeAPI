using DataAccess.AbstractDao;
using Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MemoryDao
{
    public class ItemMemoryDao : ItemDao
    {
        private static IList<Item> _items = new List<Item>()
        {
            new Item()
            {
                ItemNumber = 1,
                Description = "UN ITEM",
                RequirementNumber = 1556
            },
            new Item()
            {
                ItemNumber = 2,
                Description = "OTRO ITEM",
                RequirementNumber = 1556
            },
            new Item()
            {
                ItemNumber = 3,
                Description = "Y OTRO ITEM MAS",
                RequirementNumber = 1556
            }
        };

        private int GenerateAndGetNewItemNumber(int RequirementNumber)
        {
            Item LastItem = this.GetAllByRequirementNumber(RequirementNumber).Last();
            int NewItemNumber = LastItem.ItemNumber + 1;

            return NewItemNumber;
        }

        public override void Create(Item Item)
        {
            Item.ItemNumber = this.GenerateAndGetNewItemNumber(Item.RequirementNumber);

            _items.Add(Item);
        }

        public override void Delete(int RequirementNumber, int ItemNumber)
        {
            Item Item = this.GetByRequirementNumberAndItemNumber(RequirementNumber, ItemNumber);

            if (Item == null)
                throw new EntityNotFoundException();

            _items.Remove(Item);
        }

        public override IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public override IEnumerable<Item> GetAllByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<Item> Items = _items.Where(Item => Item.RequirementNumber.Equals(RequirementNumber)).ToList();

            if (Items != null && Items.Count() > 0)
                return Items;

            throw new EntityNotFoundException();
        }

        public override Item GetByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber)
        {
            Item FoundItem = _items.FirstOrDefault(Item => Item.RequirementNumber.Equals(RequirementNumber) && Item.ItemNumber.Equals(ItemNumber));

            if (FoundItem != null)
                return FoundItem;

            throw new EntityNotFoundException();
        }

        public override void Update(Item Item)
        {
            Item FoundItem = this.GetByRequirementNumberAndItemNumber(Item.RequirementNumber, Item.ItemNumber);
            FoundItem.Description = Item.Description;
        }
    }
}
