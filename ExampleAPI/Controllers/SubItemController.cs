using ExampleAPI.Models;
using ExampleAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExampleAPI.Controllers
{
    public class SubItemController : ApiController
    {

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? numeroItem, int? numeroSubItem, int? obra)
        {
            if (numeroItem != null && numeroItem > 0)
            {
                var Items = SubItemService.Items.Where(x => x.numeroItem.Equals(numeroItem) && x.obra.Equals(obra));

                if (Items != null && Items.Count() > 0)
                    return Ok(Items);
                else
                    return NotFound();
            }

            if (obra != null && obra > 0)
            {
                var Items = SubItemService.Items.Where(x => x.obra.Equals(obra));

                if (Items != null && Items.Count() > 0)
                    return Ok(Items);
                else
                    return NotFound();
            }

            return Ok(SubItemService.Items);
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(SubItem Item)
        {
            try
            {
                if (Item != null && Item.obra != 0 && Item.numeroSubItem != 0 && Item.numeroSubItem != 85 && !String.IsNullOrEmpty(Item.descripcion))
                {
                    SubItemService.Items.Add(Item);

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
        public IHttpActionResult Put(SubItem Item)
        {
            try
            {
                if (Item != null && Item.obra != 0 && Item.numeroSubItem != 0 && Item.numeroSubItem != 85 && !String.IsNullOrEmpty(Item.descripcion))
                {
                    SubItem ItemExistente = SubItemService.Items.FirstOrDefault(x => x.numeroSubItem.Equals(Item.numeroSubItem));

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

                SubItem Item = SubItemService.Items.FirstOrDefault(x => x.numeroSubItem.Equals(numeroItem));

                if (Item == null)
                    return NotFound();

                SubItemService.Items.Remove(Item);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
