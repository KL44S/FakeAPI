using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServerDao.Mapping
{
    internal abstract class Mapping<T, K>
    {
        protected abstract T CreateModel();
        protected abstract K CreateEntity();
        internal abstract void UnMapEntity(K Entity, T Model);
        internal abstract void MapModel(T Model, K Entity);

        internal T UnMapEntity(K Entity)
        {
            T Model = this.CreateModel();

            this.UnMapEntity(Entity, Model);

            return Model;
        }


        internal K MapModel(T Model)
        {
            K Entity = this.CreateEntity();

            this.MapModel(Model, Entity);

            return Entity;
        }

        internal IEnumerable<T> UnMapEntities(IEnumerable<K> Entities)
        {
            IList<T> Models = new List<T>();

            foreach (K Entity in Entities)
            {
                Models.Add(this.UnMapEntity(Entity));
            }

            return Models;
        }

        internal IEnumerable<K> MapModels(IEnumerable<T> Models)
        {
            IList<K> Entities = new List<K>();

            foreach (T Model in Models)
            {
                Entities.Add(this.MapModel(Model));
            }

            return Entities;
        }
    }
}
