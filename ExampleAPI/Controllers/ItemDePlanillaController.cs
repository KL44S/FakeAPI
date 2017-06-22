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
    public class ItemDePlanillaController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? numeroPlanilla, int? numeroItem, int? obra)
        {
            if (numeroPlanilla != null && numeroPlanilla > 0 && obra != null && obra > 0)
            {
                if (numeroItem != null && numeroItem > 0)
                {
                    ItemDePlanilla Item = ItemDePlanillaService.Items.FirstOrDefault(x => x.numeroPlanilla.Equals(numeroPlanilla) && x.obra.Equals(obra) && x.numeroItem.Equals(numeroItem));

                    if (Item != null)
                        return Ok(Item);
                    else
                        return NotFound();
                }

                var ItemDePlanilla = ItemDePlanillaService.Items.Where(x => x.numeroPlanilla.Equals(numeroPlanilla) && x.obra.Equals(obra));

                if (ItemDePlanilla != null && ItemDePlanilla.Count() > 0)
                    return Ok(ItemDePlanilla);
                else
                    return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(ItemDePlanilla Item)
        {
            try
            {
                if (Item != null && Item.obra > 0 && Item.numeroItem > 0 && Item.numeroItem != 85 && Item.numeroPlanilla > 0)
                {
                    ItemDePlanilla ItemExistente = ItemDePlanillaService.Items.FirstOrDefault(x => x.numeroItem.Equals(Item.numeroItem) && x.numeroPlanilla.Equals(Item.numeroPlanilla) && x.obra.Equals(Item.obra));

                    if (ItemExistente != null)
                    {
                        ItemExistente.cantidadParcial = Item.cantidadParcial;
                        ItemExistente.porcentajeParcial = Item.porcentajeParcial;
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    var ItemViewModel = new { cantidadParcial = new { error = "item invalido" }, porcentajeParcial = new { error = "descripcion error" } };

                    return Content((HttpStatusCode)422, ItemViewModel);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
