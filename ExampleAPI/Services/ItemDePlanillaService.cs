using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class ItemDePlanillaService
    {
        public static IList<ItemDePlanilla> Items = new List<ItemDePlanilla>()
        {
            new ItemDePlanilla() { numeroItem = 1, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 2, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 3, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 4, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 5, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 6, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 7, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 8, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 }
        };
    }
}