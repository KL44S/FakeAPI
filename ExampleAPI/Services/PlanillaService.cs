using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class PlanillaService
    {
        public static IList<Planilla> Planillas = new List<Planilla>()
        {
            new Planilla() { codigoDeEstado = 1, numeroPlanilla = 1, obra = 1557, fechaDesde = DateTime.Now, fechaHasta = DateTime.Now }
        };
    }
}