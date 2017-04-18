using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDesktop.Services
{
    public interface IRESTService<T>
    {
        T GetEntityById(String Id);
        void SetPath(String ApiPath);
    }
}
