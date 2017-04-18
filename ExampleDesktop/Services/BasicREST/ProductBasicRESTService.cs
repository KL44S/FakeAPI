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
            }
        }
    }
}
