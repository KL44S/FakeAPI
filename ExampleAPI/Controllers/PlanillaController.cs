using ExampleAPI.Filters;
using ExampleAPI.Models;
using ExampleAPI.Results;
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
    public class PlanillaController : BaseController
    {
        private ISheetService _sheetService;
        private SheetMappingService _sheetMappingService;

        public PlanillaController()
        {
            SheetService SheetService = new SheetService();
            SheetService.AddObserver(new SheetGeneratorService());
            this._sheetService = SheetService;

            this._sheetMappingService = new SheetMappingService();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int obra, int? numeroPlanilla)
        {
            try
            {
                if (obra > 0)
                {
                    if (!this.IsUserAssignedToRequirement(obra))
                        return new ForbiddenActionResult(Request, "");

                    if (numeroPlanilla != null && numeroPlanilla > 0)
                    {
                        Sheet Sheet = this._sheetService.GetSheetByRequirementNumberAndSheetNumber(obra, (int)numeroPlanilla);
                        PlanillaViewModel SheetViewModel = this._sheetMappingService.UnMapEntity(Sheet);

                        return Ok(SheetViewModel);
                    }
                    else
                    {
                        IEnumerable<Sheet> Sheets = this._sheetService.GetAllSheetsFromRequirement(obra);
                        IEnumerable<PlanillaViewModel> SheetViewModels = this._sheetMappingService.UnMapEntities(Sheets);

                        return Ok(SheetViewModels);
                    }
                }

                return BadRequest();
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
        public IHttpActionResult Put(PlanillaViewModel PlanillaViewModel)
        {
            try
            {
                if (PlanillaViewModel != null)
                {
                    Sheet Sheet = this._sheetMappingService.MapViewModel(PlanillaViewModel);

                    //Validas el cambio de estado de la planilla
                    this._sheetService.UpdateSheet(Sheet);

                    return Ok();
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
