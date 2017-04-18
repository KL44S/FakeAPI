using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExampleDesktop.Services
{
    public class ProductBasicRESTService : BasicRESTService<Product>
    {
        //Esta forma de invocarlo "remueve" la asincronicidad. Es decir que hasta que el método no termina, el método invocante 
        //no sigue su flujo normal. Por lo tanto hasta que la API no devuelve datos no se levanta la interfaz del winform (sólo a modo de ejemplo)
        protected override async Task SearchProductAsync(string Id)
        {
            using (var Client = new HttpClient())
            {
                String FullPath = this._apiPath + "/" + Id;
                HttpResponseMessage response = Client.GetAsync(FullPath).Result;

                if (response.IsSuccessStatusCode)
                {
                    this._entity = await response.Content.ReadAsAsync<Product>();
                }
                else
                {
                    //Excepción genérica. Aquí habría que capturar el error específico devuelto en el código HTTP de la API y obrar
                    //en consecuencia
                    throw new Exception("Ha ocurrido un error");
                }
            }
        }
    }
}
