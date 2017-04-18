using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDesktop.Services
{
    public abstract class BasicRESTService<T> : IRESTService<T>
    {
        protected String _apiPath { get; set; }
        protected T _entity;

        public T GetEntityById(string Id)
        {
            this.SearchProductAsync(Id);
            return this._entity;
        }

        //Este método tiene que buscar la entidad consumiento el método GET de la API REST y setear el atributo entity
        //Es la forma de evitar los Task/async/wait en las clases "clientes"
        protected abstract Task SearchProductAsync(String Id);

        public void SetPath(string ApiPath)
        {
            this._apiPath = ApiPath;
        }
    }
}
