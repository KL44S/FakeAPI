using ExampleAPI.Filters;
using ExampleAPI.Models;
using ExampleAPI.Results;
using ExampleAPI.Services;
using Exceptions;
using Model;
using Services;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Net;
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
        public IHttpActionResult Get(int obra, int numeroPlanilla, int? numeroItem)
        {
            try
            {
                if (obra >= 0 && numeroPlanilla >= 0)
                {
                    if (!this.IsUserAssignedToRequirement(obra))
                        return new ForbiddenActionResult(Request, "");

                    IEnumerable<SheetItem> SheetItems = null;

                    if (numeroItem != null)
                    {
                        SheetItems = this._sheetItemService.GetSheetItemsFromRequirementNumberAndSheetNumberAndItemNumber(obra, numeroPlanilla,
                                                                                                                            (int)numeroItem);
                    }
                    else
                    {
                        SheetItems = this._sheetItemService.GetSheetItemsFromRequirementNumberAndSheetNumber(obra,
                                                                                                    numeroPlanilla);
                    }

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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(ItemDePlanillaViewModel SheetItemViewModel)
        {
            try
            {
                if (SheetItemViewModel != null)
                {
                    if (!this.IsUserAssignedToRequirement(SheetItemViewModel.obra))
                        return new ForbiddenActionResult(Request, "");

                    if (!this.MayCurrentUserDoAction(Constants.EditSheetItemAction))
                        return new ForbiddenActionResult(Request, "");

                    SheetItem SheetItem = this._sheetItemMappingService.MapViewModel(SheetItemViewModel);
                    User User = this.GetCurrentUser();

                    if (!this._sheetItemService.MayUserEditSubItem(User, SheetItem))
                        return new ForbiddenActionResult(Request, "");

                    IDictionary<Attributes.SheetItem, String> ValidationErrors = this._sheetItemService.GetValidationErrors(SheetItem);

                    if (ValidationErrors.Count > 0)
                    {
                        var SheetItemValidationObject = SheetItemValidationObjectGeneratorService.GetValidationObject(ValidationErrors, SheetItem);

                        return Content((HttpStatusCode)422, SheetItemValidationObject);
                    }
                    else
                    {
                        this._sheetItemService.Update(SheetItem);
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
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

        }
    }
}
