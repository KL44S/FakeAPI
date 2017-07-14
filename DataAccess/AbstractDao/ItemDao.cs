using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractDao
{
    public abstract class ItemDao : IDao<Item>
    {
        public abstract void Create(Item Item);
        public abstract IEnumerable<Item> GetAll();
        public abstract IEnumerable<Item> GetAllByRequirementNumber(int RequirementNumber);
        public abstract Item GetByRequirementNumberAndItemNumber(int RequirementNumber, int ItemNumber);
        public abstract void Update(Item Item);
        public abstract void Delete(int RequirementNumber, int ItemNumber);
    }
}
