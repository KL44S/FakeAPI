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
    public class ObraController : ApiController
    {
        private IRequirementService _requirementService = new RequirementService();
        private MappingService<Requirement, ObraViewModel> _requirementMappingService = new RequirementMappingService();

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? obra)
        {
            try
            {
                if (obra != null && obra >= 0)
                {
                    Requirement Requirement = this._requirementService.GetRequirementByRequirementNumber((int)obra);

                    if (Requirement != null)
                    {
                        ObraViewModel ObraViewModel = this._requirementMappingService.UnMapEntity(Requirement);
                        return Ok(ObraViewModel);
                    }

                    else
                        return NotFound();
                }

                IEnumerable<Requirement> Requirements = this._requirementService.GetAllRequirements();
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
            catch (Exception)
            {
                return InternalServerError();
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

        // POST: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(ObraViewModel Obra)
        {
            try
            {
                if (Obra != null)
                {
                    Requirement Requirement = this._requirementMappingService.MapViewModel(Obra);
                    IDictionary<Requirement.Attributes, String > ValidationErrors = this._requirementService.GetValidationErrors(Requirement);

                    if (ValidationErrors.Count() > 0)
                    {
                        var RequirementValidationObject = new
                        {
                            obra = new
                            {
                                value = Requirement.RequirementNumber,
                                error = ValidationErrors[Requirement.Attributes.RequirementNumber]
                            },
                            oco = new
                            {
                                value = Requirement.PurchaseOrder,
                                error = ValidationErrors[Requirement.Attributes.PurchaseOrder]
                            },
                            ejercicioOco = new
                            {
                                value = Requirement.PurchaseOrderExcercise,
                                error = ValidationErrors[Requirement.Attributes.PurchaseOrderExcercise]
                            },
                            proveedor = new
                            {
                                value = Requirement.Provider,
                                error = ValidationErrors[Requirement.Attributes.Provider]
                            },
                            diasDeCertificacion = new
                            {
                                value = Requirement.CertificationDays,
                                error = ValidationErrors[Requirement.Attributes.CertificationDays]
                            },
                        };

                        return Content((HttpStatusCode)422, RequirementValidationObject);
                    }
                    else
                    {
                        this._requirementService.Create(Requirement);
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
        public IHttpActionResult Put(CreateObra Obra)
        {
            try
            {
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor) && Obra.cuits != null && Obra.cuits.Count() > 0)
                {
                    Obra ViejaObra = ObraService.Obras.FirstOrDefault(x => x.obra.Equals(Obra.obra));

                    if (ViejaObra == null)
                        return NotFound();

                    ViejaObra.obra = Obra.obra;
                    ViejaObra.oco = Obra.oco;
                    ViejaObra.ejercicioObra = Obra.ejercicioObra;
                    ViejaObra.proveedor = Obra.proveedor;
                    ViejaObra.cuits = Obra.cuits.ToList();
                    ViejaObra.diasCertificacion = Obra.diasCertificacion;

                    return Ok();
                }
                else
                {
                    var ObraViewModel = new { obra = new { error = "obra invalida" }, oco = new { error = "oco eror" }, ejercicioOco = new { error = "ejericcio error" }, proveedor = new { error = "proveedor error" }, diasCertificacion = new { error = "error dias" } };

                    return Content((HttpStatusCode)422, ObraViewModel);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Obra/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Delete(int obra)
        {
            try
            {
                if (obra <= 0)
                    return BadRequest();

                Obra Obra = ObraService.Obras.FirstOrDefault(x => x.obra.Equals(obra));

                if (Obra == null)
                    return NotFound();

                ObraService.Obras.Remove(Obra);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
