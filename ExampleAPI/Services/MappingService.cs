using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public abstract class MappingService <T, K>
    {
        public abstract K UnMapEntity(T Entity);
        public abstract T MapViewModel(K ViewModel);
    }
}