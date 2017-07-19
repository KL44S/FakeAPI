using ExampleAPI.Models;
using Services.Implementations;
using ExampleAPI.Services;
using Model;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Exceptions;

namespace ExampleAPI.Controllers
{
    public class SubItemController : ApiController
    {
        private ISubItemService _subItemService = new SubItemService();
        private SubItemMappingService _subItemMappingService = new SubItemMappingService();

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int obra, int? numeroItem, int? numeroSubItem)
        {
            try
            {
                IEnumerable<SubItem> SubItems;

                if (numeroItem != null)
                {
                    SubItems = this._subItemService.GetSubItemsByRequirementNumberAndItemNumber((int)(obra), (int)numeroItem);

                    if (SubItems != null)
                        return Ok(this._subItemMappingService.UnMapEntities(SubItems));
                    else
                        return NotFound();
                }

                SubItems = this._subItemService.GetSubItemsByRequirementNumber((int)(obra));

                if (SubItems != null)
                {
                    IEnumerable<SubItemViewModel> SubItemViewModels = this._subItemMappingService.UnMapEntities(SubItems);
                    return Ok(SubItemViewModels);
                }
                else
                    return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        /*[EnableCors(origins: "*", headers: "*", methods: "*")]
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

        }*/

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int obra, int numeroItem, int numeroSubItem)
        {
            try
            {
                if (obra <= 0 || numeroItem <= 0 || numeroSubItem <= 0)
                    return BadRequest();

                this._subItemService.Delete(obra, numeroItem, numeroSubItem);

                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
