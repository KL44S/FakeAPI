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
using ExampleAPI.Filters;
using ExampleAPI.Results;

namespace ExampleAPI.Controllers
{
    [AuthFilter]
    public class SubItemController : BaseController
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
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(SubItemViewModel SubItem)
        {
            try
            {
                if (!this.UserHasRol(Constants.Constants.AdminRoleId) && !this.UserHasRol(Constants.Constants.BuilderRoleId))
                    return new ForbiddenActionResult(Request, "");

                if (SubItem != null)
                {
                    SubItem SubItemModel = this._subItemMappingService.MapViewModel(SubItem);

                    IDictionary<Attributes.SubItem, String> ValidationErrors = this._subItemService.GetValidationErrors(SubItemModel);

                    if (ValidationErrors.Count() > 0)
                    {
                        var ItemValidationObject = SubItemValidationObjectGeneratorService.GetValidationObject(ValidationErrors, SubItemModel);

                        return Content((HttpStatusCode)422, ItemValidationObject);
                    }
                    else
                    {
                        this._subItemService.Create(SubItemModel);
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

        
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(SubItemViewModel SubItem)
        {
            try
            {
                if (!this.UserHasRol(Constants.Constants.AdminRoleId) && !this.UserHasRol(Constants.Constants.BuilderRoleId))
                    return new ForbiddenActionResult(Request, "");

                if (SubItem != null)
                {
                    SubItem SubItemModel = this._subItemMappingService.MapViewModel(SubItem);

                    IDictionary<Attributes.SubItem, String> ValidationErrors = this._subItemService.GetValidationErrors(SubItemModel);

                    if (ValidationErrors.Count() > 0)
                    {
                        var ItemValidationObject = SubItemValidationObjectGeneratorService.GetValidationObject(ValidationErrors, SubItemModel);

                        return Content((HttpStatusCode)422, ItemValidationObject);
                    }
                    else
                    {
                        this._subItemService.Update(SubItemModel);
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int obra, int numeroItem, int numeroSubItem)
        {
            try
            {
                if (!this.UserHasRol(Constants.Constants.AdminRoleId) && !this.UserHasRol(Constants.Constants.BuilderRoleId))
                    return new ForbiddenActionResult(Request, "");

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
