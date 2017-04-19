using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDesktop.Services
{
    public class BasicRESTService<T> : IRESTService<T>
    {
        protected String _apiPath { get; set; }
        protected T _entity;

        public T GetEntityById(string Id)
        {
            this.SearchEntityAsync(Id);
            return this._entity;
        }

        //Este método tiene que buscar la entidad consumiento el método GET de la API REST y setear el atributo entity
        //Es la forma de evitar los Task/async/wait en las clases "clientes"
        private async void SearchEntityAsync(String Id)
        {
            using (var Client = new HttpClient())
            {
                String FullPath = this._apiPath + "/" + Id;
                this.PutTokenInHeader(Client);

                HttpResponseMessage response = Client.GetAsync(FullPath).Result;

                if (response.IsSuccessStatusCode)
                {
                    this._entity = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    //Excepción genérica. Aquí habría que capturar el error específico devuelto en el código HTTP de la API y obrar
                    //en consecuencia
                    throw new Exception("Ha ocurrido un error");
                }
            }
        }

        public void SetPath(string ApiPath)
        {
            this._apiPath = ApiPath;
        }

        private void PutTokenInHeader(HttpClient Client)
        {
            if (!String.IsNullOrEmpty(Statics.Statics.Token))
            {
                Client.DefaultRequestHeaders.Add(Statics.Statics.AuthenticationHeader, Statics.Statics.Token);
            }
        }

        private async void ProccessEntityAsync(T Entity)
        {
            using (var Client = new HttpClient())
            {
                this.PutTokenInHeader(Client);

                HttpResponseMessage response = Client.PostAsJsonAsync(this._apiPath, Entity).Result;

                if (response.IsSuccessStatusCode)
                {
                    this._entity = await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    //Excepción genérica. Aquí habría que capturar el error específico devuelto en el código HTTP de la API y obrar
                    //en consecuencia
                    throw new Exception("Ha ocurrido un error");
                }
            }
        }

        public T PostEntity(T Entity)
        {
            this.ProccessEntityAsync(Entity);
            return this._entity;
        }
    }
}
