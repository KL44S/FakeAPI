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

        public override void Create(Item Item)
        {
            _items.Add(Item);
        }

        public override IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public override IEnumerable<Item> GetAllByRequirementNumber(int RequirementNumber)
        {
            IEnumerable<Item> Items = _items.Where(Item => Item.RequirementNumber.Equals(RequirementNumber));

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
