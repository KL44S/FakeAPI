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
    public class EstadoDePlanillaController : ApiController
    {
        private ISheetStateService _sheetStateService;
        private SheetStateMapping _sheetStateMapping;

        public EstadoDePlanillaController()
        {
            this._sheetStateService = new SheetStateService();
            this._sheetStateMapping = new SheetStateMapping();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<SheetState> SheetStates = this._sheetStateService.GetSheetStates();
                IEnumerable<EstadoDePlanillaViewModel> SheetStateViewModels = this._sheetStateMapping.UnMapEntities(SheetStates);

                return Ok(SheetStateViewModels);
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
        public IHttpActionResult Get(int codigoDeEstado)
        {
            try
            {
                if (codigoDeEstado > 0)
                {
                    SheetState SheetState = this._sheetStateService.GetSheetStateById(codigoDeEstado);
                    EstadoDePlanillaViewModel EstadoDePlanillaViewModel = this._sheetStateMapping.UnMapEntity(SheetState);

                    return Ok(EstadoDePlanillaViewModel);
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
