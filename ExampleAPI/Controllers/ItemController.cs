using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExampleAPI.Controllers
{
    public class ItemController : ApiController
    {
        private static IList<Item> _items = new List<Item>()
        {
            new Item() { numeroItem = 1, obra = 1556, descripcion = "TRABAJOS PRELIMINARES" },
            new Item() { numeroItem = 2, obra = 1556, descripcion = "Documentación gráfica, proyecto ejecutivo. Presentación ante orgnaismos oficiales" }
        };

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? numeroItem, int? obra)
        {
            if (numeroItem != null && numeroItem > 0)
            {
                var Items = _items.Where(x => x.numeroItem.Equals(numeroItem));

                if (Items != null && Items.Count() > 0)
                    return Ok(Items);
                else
                    return NotFound();
            }

            if (obra != null && obra > 0)
            {
                var Items = _items.Where(x => x.obra.Equals(obra));

                if (Items != null && Items.Count() > 0)
                    return Ok(Items);
                else
                    return NotFound();
            }

            return Ok(_items);
        }
    }
}
