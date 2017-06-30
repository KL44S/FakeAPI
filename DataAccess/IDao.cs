using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDao<T>
    {
        void Create(T Entity);
        void Update(T Entity);
        IEnumerable<T> GetAll();
    }
}
