using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using ExampleAPI.Filters;
using System.Web.Http.Results;

namespace ExampleAPI.Controllers
{
    [SecurityFilter]
    public class ProductController : ApiController
    {
        // GET: api/Product/5
        public IHttpActionResult Get(String id)
        {
            try
            {
                Product Product = Statics.Statics.Product;

                if (Product.ProductId.Equals(id))
                {
                    return Ok(Product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception Exception)
            {
                return new BadRequestErrorMessageResult(Exception.Message, this);
            }

        }
    }
}
