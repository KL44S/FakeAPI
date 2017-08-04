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
            this._sheetService = new SheetService();
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


        /*[EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(int? obra)
        {
            if (obra != null && obra > 0)
            {
                Planilla Planilla = new Planilla();
                Planilla.obra = (int)obra;
                Planilla.fechaHasta = DateTime.Now;
                Planilla.fechaDesde = DateTime.Now;
                Planilla.codigoDeEstado = 1;
                Planilla.numeroPlanilla = PlanillaService.Planillas.Last().numeroPlanilla + 1;

                PlanillaService.Planillas.Add(Planilla);
                IList<ItemDePlanilla> ItemsDePlanilla = new List<ItemDePlanilla>();

                foreach (var Item in SubItemService.Items)
                {
                    ItemDePlanilla ItemDePlanilla = new ItemDePlanilla()
                    {
                        numeroItem = Item.numeroSubItem, obra = (int)obra, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = Planilla.numeroPlanilla
                    };

                    ItemDePlanillaService.Items.Add(ItemDePlanilla);
                }

                return Ok();
            }

            return BadRequest();
        }*/
    }
}
