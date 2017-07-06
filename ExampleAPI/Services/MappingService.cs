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

        public IEnumerable<T> MapViewModels(IEnumerable<K> ViewModels)
        {
            IList<T> Entities = new List<T>();

            foreach (K ViewModel in ViewModels)
            {
                Entities.Add(this.MapViewModel(ViewModel));
            }

            return Entities;
        }

        public IEnumerable<K> UnMapEntities(IEnumerable<T> Entities)
        {
            IList<K> ViewModels = new List<K>();

            foreach (T Entity in Entities)
            {
                ViewModels.Add(this.UnMapEntity(Entity));
            }

            return ViewModels;
        }
    }
}