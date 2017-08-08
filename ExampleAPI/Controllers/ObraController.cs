using ExampleAPI.Filters;
using ExampleAPI.Models;
using ExampleAPI.Results;
using ExampleAPI.Services;
using Exceptions;
using Model;
using Services.Abstractions;
using Services.Implementations;
using Services.Validators.Implementations;
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
    public class ObraController : BaseController
    {
        private IRequirementService _requirementService = new RequirementService();
        private IUserService _userService = new UserService();
        private MappingService<Requirement, ObraViewModel> _requirementMappingService = new RequirementMappingService();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            try
            {
                String CurrentUserCuit = this.GetCurrentUserCuit();
                IEnumerable<Requirement> Requirements = this._requirementService.GetAllRequirementsByCuit(CurrentUserCuit);

                return this.MapAndReturnRequirements(Requirements);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? obra)
        {
            try
            {
                if (obra != null && obra >= 0)
                {
                    if (!this.IsUserAssignedToRequirement((int)obra))
                        return new ForbiddenActionResult(Request, "");

                    Requirement Requirement = this._requirementService.GetRequirementByRequirementNumber((int)obra);

                    if (Requirement != null)
                    {
                        ObraViewModel ObraViewModel = this._requirementMappingService.UnMapEntity(Requirement);
                        return Ok(ObraViewModel);
                    }

                    else
                        return NotFound();
                }

                String CurrentUserCuit = this.GetCurrentUserCuit();

                IEnumerable<Requirement> Requirements = this._requirementService.GetAllRequirementsByCuit(CurrentUserCuit);
                return this.MapAndReturnRequirements(Requirements);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        private IHttpActionResult MapAndReturnRequirements(IEnumerable<Requirement> Requirements)
        {   
            if (Requirements.Count() > 0)
            {
                IEnumerable<ObraViewModel> ObrasViewModel = this._requirementMappingService.UnMapEntities(Requirements);
                return Ok(ObrasViewModel);
            }

            return NotFound();
        }

        private void CreateAndSaveAssignment(int RequirementNumber)
        {
            RequirementUser RequirementUser = new RequirementUser();
            RequirementUser.RequirementNumber = RequirementNumber;
            RequirementUser.Cuit = this.GetCurrentUserCuit();

            IRequirementUserService RequirementUserService = new RequirementUserService();
            RequirementUserService.SaveRequirementUser(RequirementUser);
        }

        // POST: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(ObraViewModel Obra)
        {
            try
            {
                if (!this.MayCurrentUserDoAction(Constants.Constants.CreateRequirementAction))
                    return new ForbiddenActionResult(Request, "");

                if (Obra != null)
                {
                    Requirement Requirement = this._requirementMappingService.MapViewModel(Obra);
                    IDictionary<Attributes.Requirement, String > ValidationErrors = this._requirementService.GetValidationErrors(Requirement);

                    //Existencia de la obra
                    ExistingRequirementNumberValidator ExistingRequirementNumberValidator = new ExistingRequirementNumberValidator();
                    ExistingRequirementNumberValidator.RequirementNumberToValidate = Requirement.RequirementNumber;
                    ExistingRequirementNumberValidator.ErrorMessages = ValidationErrors;
                    ExistingRequirementNumberValidator.Validate();

                    if (ValidationErrors.Count() > 0)
                    {
                        var RequirementValidationObject = RequirementValidationObjectGeneratorService.GetValidationObject(ValidationErrors, Requirement);

                        return Content((HttpStatusCode)422, RequirementValidationObject);
                    }
                    else
                    {
                        this._requirementService.Create(Requirement);
        
                        try
                        {
                            this.CreateAndSaveAssignment(Requirement.RequirementNumber);
                        }
                        catch (Exception Exception)
                        {
                            try
                            {
                                this._requirementService.Delete(Requirement.RequirementNumber);
                            }
                            catch (EntityNotFoundException) { }

                            throw Exception;
                        }

                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(ObraViewModel Obra)
        {
            try
            {
                if (!this.MayCurrentUserDoAction(Constants.Constants.EditRequirementAction))
                    return new ForbiddenActionResult(Request, "");

                if (Obra != null)
                {
                    if (!this.IsUserAssignedToRequirement(Obra.obra))
                        return new ForbiddenActionResult(Request, "");

                    Requirement Requirement = this._requirementMappingService.MapViewModel(Obra);
                    IDictionary<Attributes.Requirement, String> ValidationErrors = this._requirementService.GetValidationErrors(Requirement);

                    if (ValidationErrors.Count() > 0)
                    {
                        var RequirementValidationObject = RequirementValidationObjectGeneratorService.GetValidationObject(ValidationErrors, Requirement);

                        return Content((HttpStatusCode)422, RequirementValidationObject);
                    }
                    else
                    {
                        this._requirementService.Update(Requirement);
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
        }

        // DELETE: api/Obra/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int obra)
        {
            try
            {
                if (!this.MayCurrentUserDoAction(Constants.Constants.RemoveRequirementAction))
                    return new ForbiddenActionResult(Request, "");

                if (!this.IsUserAssignedToRequirement(obra))
                    return new ForbiddenActionResult(Request, "");

                this._requirementService.Delete(obra);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
