using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IObserver
    {
        void IhaveBeenChanged(object InvokingObject, object Params);
        void IhaveBeenChanged(object InvokingObject);
    }
}
