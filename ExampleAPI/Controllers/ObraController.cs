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
    public class ObraController : ApiController
    {

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(String cuit)
        {
            if (!String.IsNullOrEmpty(cuit))
            {
                var Obras = ObraService.Obras.Where(x => x.cuits.Contains(cuit));

                if (Obras != null && Obras.Count() > 0)
                    return Ok(Obras);
                else
                    return NotFound();
            }
     
            return Ok(ObraService.Obras);
        }

        // GET: api/Obra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(CreateObra Obra)
        {
            try
            {
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor) && Obra.cuits != null && Obra.cuits.Count() > 0)
                {
                    Obra.id = ObraService.Obras.Last().id + 1;

                    Obra nuevaObra = new Obra() { cuits =  Obra.cuits.ToList(), id = Obra.id, obra = Obra.obra, ejercicioObra = Obra.ejercicioObra, oco = Obra.oco, proveedor = Obra.proveedor };

                    ObraService.Obras.Add(nuevaObra);

                    return Ok();
                }
                else
                {
                    var ObraViewModel = new { obra = new { error = "obra invalida" }, oco = new { error = "oco eror" }, ejercicioOco = new { error = "ejericcio error" }, proveedor = new { error = "proveedor error" } };

                    return Content((HttpStatusCode)422, ObraViewModel);
                }
            }
            catch(Exception)
            {
                return BadRequest();
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


                    return Ok();
                }
                else
                {
                    var ObraViewModel = new { obra = new { error = "obra invalida" }, oco = new { error = "oco eror" }, ejercicioOco = new { error = "ejericcio error" }, proveedor = new { error = "proveedor error" } };

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
