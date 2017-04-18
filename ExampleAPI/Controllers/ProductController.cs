using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleAPI.Models;
using ExampleAPI.Filters;

namespace ExampleAPI.Controllers
{
    [SecurityFilter]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public IHttpActionResult Get(int id)
        {
            //Harcode a modo de prueba
            Product Product = new Product();
            Product.ProductId = "1";
            Product.ProductDescription = "Un producto";

            if (Product.ProductId.Equals(id))
            {
                return Ok(Product);
            }
            else
            {
                return NotFound();        
            }
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
            //TODO: implementar
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
            //TODO: implementar
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            //TODO: implementar
        }
    }
}
