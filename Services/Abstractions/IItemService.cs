using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IItemService
    {
        IEnumerable<Item> GetItemsByRequirementNumber(int RequirementNumber);
        IEnumerable<Item> GetAllItems();
        Item GetItemByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        void Create(Item Item);
        void Update(Item Item);
        void Delete(int RequirementNumber, int ItemNumber);
        IDictionary<Attributes.Item, String> GetValidationErrors(Item Item);
    }
}
