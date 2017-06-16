using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class ObraService
    {
        public static IList<Obra> Obras = new List<Obra>()
        {
            new Obra()
            {
                id = 1,
                obra = 1556,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
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
                diasCertificacion = 30,
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
                diasCertificacion = 30,
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
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 5,
                obra = 1560,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 6,
                obra = 1561,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 7,
                obra = 1562,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 8,
                obra = 1563,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 9,
                obra = 1564,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 10,
                obra = 1565,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 11,
                obra = 1566,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 12,
                obra = 1567,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 13,
                obra = 1568,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 14,
                obra = 1569,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 15,
                obra = 1570,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 16,
                obra = 1571,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 17,
                obra = 1572,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 18,
                obra = 1573,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 19,
                obra = 1574,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 20,
                obra = 1575,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 14,
                obra = 1576,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 21,
                obra = 1577,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 22,
                obra = 1578,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 23,
                obra = 1579,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 24,
                obra = 1580,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 25,
                obra = 1581,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 26,
                obra = 1582,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 27,
                obra = 1583,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 28,
                obra = 1584,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 29,
                obra = 1585,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            },
            new Obra()
            {
                id = 30,
                obra = 1586,
                oco = 143,
                ejercicioObra = 2015,
                proveedor = "COTO CISCA - 15464 - SA",
                diasCertificacion = 30,
                cuits = new List<String>()
                {
                    "12345678"
                }
            }
        };
    }
}