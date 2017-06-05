using ExampleAPI.Models;
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
        private static IList<Obra> _obras = new List<Obra>()
        {
            new Obra()
            {
                id = 1,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678",
                    "12345678910",
                    "755433"
                }
            },
            new Obra()
            {
                id = 2,
                obra = 1557,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "PANTENE - 15464 - SA",
                cuits = new List<String>()
                {
                    "6346634",
                    "12345678"
                }
            },
            new Obra()
            {
                id = 3,
                obra = 1558,
                oco = 142,
                ejercicioObra = 2016,
                proveedor = "SOMEONE - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678910",
                    "12345678"
                }
            },
            new Obra()
            {
                id = 4,
                obra = 1559,
                oco = 142,
                ejercicioObra = 2016,
                proveedor = "ANOTHER - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            }
        };

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(String cuit)
        {
            if (!String.IsNullOrEmpty(cuit))
            {
                var Obras = _obras.Where(x => x.cuits.Contains(cuit));

                if (Obras != null && Obras.Count() > 0)
                    return Ok(Obras);
                else
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
     
            return Ok(_obras);
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
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor) && !String.IsNullOrEmpty(Obra.cuit))
                {
                    Obra.id = _obras.Last().id + 1;

                    Obra nuevaObra = new Obra() { cuits = new List<String>() { Obra.cuit }, id = Obra.id, obra = Obra.obra, ejercicioObra = Obra.ejercicioObra, oco = Obra.oco, proveedor = Obra.proveedor };

                    _obras.Add(nuevaObra);

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

        // PUT: api/Obra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Obra/5
        public void Delete(int id)
        {
        }
    }
}
