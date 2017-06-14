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


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(Item Item)
        {
            try
            {
                if (Item != null && Item.obra != 0 && Item.numeroItem != 0 && Item.numeroItem != 85 && !String.IsNullOrEmpty(Item.descripcion))
                {
                    _items.Add(Item);

                    return Ok();
                }
                else
                {
                    var ItemViewModel = new { numeroItem = new { error = "item invalido" }, descripcion = new { error = "descripcion error" }, obra = new { error = "" } };

                    return Content((HttpStatusCode)422, ItemViewModel);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(Item Item)
        {
            try
            {
                if (Item != null && Item.obra != 0 && Item.numeroItem != 0 && Item.numeroItem != 85 && !String.IsNullOrEmpty(Item.descripcion))
                {
                    Item ItemExistente = _items.FirstOrDefault(x => x.numeroItem.Equals(Item.numeroItem));

                    if (ItemExistente != null)
                    {
                        ItemExistente.descripcion = Item.descripcion;
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                    
                }
                else
                {
                    var ItemViewModel = new { numeroItem = new { error = "item invalido" }, descripcion = new { error = "descripcion error" }, obra = new { error = "" } };

                    return Content((HttpStatusCode)422, ItemViewModel);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int numeroItem)
        {
            try
            {
                if (numeroItem <= 0)
                    return BadRequest();

                Item Item = _items.FirstOrDefault(x => x.numeroItem.Equals(numeroItem));

                if (Item == null)
                    return NotFound();

                _items.Remove(Item);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
