using ExampleAPI.Models;
using ExampleAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExampleAPI.Controllers
{
    public class PlanillaController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? numeroPlanilla, int? obra)
        {
            if (obra != null && obra > 0)
            {
                if (numeroPlanilla != null && numeroPlanilla > 0)
                {
                    var Planilla = PlanillaService.Planillas.FirstOrDefault(x => x.numeroPlanilla.Equals(numeroPlanilla) && x.obra.Equals(obra));

                    if (Planilla != null)
                        return Ok(Planilla);
                    else
                        return NotFound();
                }

                var Planillas = PlanillaService.Planillas.Where(x => x.obra.Equals(obra));

                if (Planillas != null && Planillas.Count() > 0)
                    return Ok(Planillas);
                else
                    return NotFound();
            }

            return BadRequest();
        }



        [EnableCors(origins: "*", headers: "*", methods: "*")]
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

                return Ok();
            }

            return BadRequest();
        }
    }
}
