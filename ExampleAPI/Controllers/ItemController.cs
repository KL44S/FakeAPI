using ExampleAPI.Models;
using ExampleAPI.Services;
using Exceptions;
using Model;
using Services.Abstractions;
using Services.Implementations;
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
        private IItemService _itemService = new ItemService();
        private ItemMapping _itemMapping = new ItemMapping();

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? obra, int? numeroItem)
        {
            try
            {
                IEnumerable<Item> Items;

                if (obra != null)
                {
                    if (numeroItem != null)
                    {
                        Item Item = this._itemService.GetItemByRequirementNumberAndItemNumber((int)(obra), (int)numeroItem);

                        if (Item != null)
                            return Ok(this._itemMapping.UnMapEntity(Item));
                        else
                            return NotFound();
                    }

                    Items = this._itemService.GetItemsByRequirementNumber((int)(obra));

                    if (Items != null)
                    {
                        IEnumerable<ItemViewModel> ItemViewModels = this._itemMapping.UnMapEntities(Items);
                        return Ok(ItemViewModels);
                    }
                    else
                        return NotFound();
                }

                Items = this._itemService.GetAllItems();

                return Ok(this._itemMapping.UnMapEntities(Items));
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(ItemViewModel Item)
        {
            try
            {
                if (Item != null)
                {
                    Item ModelItem = this._itemMapping.MapViewModel(Item);

                    IDictionary<Item.Attributes, String> ValidationErrors = this._itemService.GetValidationErrors(ModelItem);

                    if (ValidationErrors.Count() > 0)
                    {
                        var ItemValidationObject = ItemValidationObjectGeneratorService.GetValidationObject(ValidationErrors, ModelItem);

                        return Content((HttpStatusCode)422, ItemValidationObject);
                    }
                    else
                    {
                        this._itemService.Create(ModelItem);
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(ItemViewModel Item)
        {
            try
            {
                if (Item != null)
                {
                    Item ModelItem = this._itemMapping.MapViewModel(Item);

                    IDictionary<Item.Attributes, String> ValidationErrors = this._itemService.GetValidationErrors(ModelItem);

                    if (ValidationErrors.Count() > 0)
                    {
                        var ItemValidationObject = ItemValidationObjectGeneratorService.GetValidationObject(ValidationErrors, ModelItem);

                        return Content((HttpStatusCode)422, ItemValidationObject);
                    }
                    else
                    {
                        this._itemService.Update(ModelItem);
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
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
        
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int obra, int numeroItem)
        {
            try
            {
                if (obra <= 0 || numeroItem <= 0)
                    return BadRequest();

                this._itemService.Delete(obra, numeroItem);

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
