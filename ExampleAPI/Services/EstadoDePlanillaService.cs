using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class EstadoDePlanillaService
    {
        public static IList<EstadoDePlanilla> EstadosDePlanillas { get; set; } = new List<EstadoDePlanilla>()
        {
            new EstadoDePlanilla() { codigoDeEstado = 1, descripcion = "Ingresada" },
            new EstadoDePlanilla() { codigoDeEstado = 2, descripcion = "Confirmada" },
            new EstadoDePlanilla() { codigoDeEstado = 3, descripcion = "Autorizada" }
        };
    }
}