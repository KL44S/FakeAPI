using ExampleAPI.Filters;
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
    [AuthFilter]
    public class ItemDePlanillaController : BaseController
    {
        private ISheetItemService _sheetItemService;
        private SheetItemMappingService _sheetItemMappingService;

        public ItemDePlanillaController()
        {
            this._sheetItemService = new SheetItemService();
            this._sheetItemMappingService = new SheetItemMappingService();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int obra, int numeroPlanilla)
        {
            try
            {
                if (obra >= 0 && numeroPlanilla >= 0)
                {
                    IEnumerable<SheetItem> SheetItems = this._sheetItemService.GetSheetItemsFromRequirementNumberAndSheetNumber(obra,
                                                                                                    numeroPlanilla);
                    IEnumerable<ItemDePlanillaViewModel> SheetItemsViewModels = this._sheetItemMappingService.UnMapEntities(SheetItems);

                    return Ok(SheetItemsViewModels);
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
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /*[EnableCors(origins: "*", headers: "*", methods: "*")]
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

        }*/
    }
}
