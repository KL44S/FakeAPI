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
            },
            new Obra()
            {
                id = 5,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 6,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 7,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 8,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 9,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 10,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 11,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 12,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 13,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 14,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 15,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 16,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 17,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 18,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 19,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 20,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 14,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 21,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 22,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 23,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 24,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 25,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 26,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 27,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 28,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 29,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 30,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
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
                    return NotFound();
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
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor) && Obra.cuits != null && Obra.cuits.Count() > 0)
                {
                    Obra.id = _obras.Last().id + 1;

                    Obra nuevaObra = new Obra() { cuits =  Obra.cuits.ToList(), id = Obra.id, obra = Obra.obra, ejercicioObra = Obra.ejercicioObra, oco = Obra.oco, proveedor = Obra.proveedor };

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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(CreateObra Obra)
        {
            try
            {
                if (Obra != null && Obra.obra != 0 && Obra.oco != 0 && Obra.ejercicioObra != 0 && Obra.ejercicioObra != 2018 && !String.IsNullOrEmpty(Obra.proveedor) && Obra.cuits != null && Obra.cuits.Count() > 0)
                {
                    Obra ViejaObra = _obras.FirstOrDefault(x => x.obra.Equals(Obra.obra));

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

                Obra Obra = _obras.FirstOrDefault(x => x.obra.Equals(obra));

                if (Obra == null)
                    return NotFound();

                _obras.Remove(Obra);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
