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
                proveedor = "COTO CISCA - 15464 - SA"
            },
            new Obra()
            {
                id = 2,
                obra = 1557,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "PANTENE - 15464 - SA"
            },
            new Obra()
            {
                id = 3,
                obra = 1558,
                oco = 142,
                ejercicioObra = 2016,
                proveedor = "SOMEONE - 15464 - SA"
            },
            new Obra()
            {
                id = 4,
                obra = 1559,
                oco = 142,
                ejercicioObra = 2016,
                proveedor = "ANOTHER - 15464 - SA"
            }
        };

        // GET: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            return Ok(_obras);
            //return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        // GET: api/Obra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Obra
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(Obra Obra)
        {
            try
            {
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor))
                {
                    Obra.id = _obras.Last().id + 1;

                    _obras.Add(Obra);

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
