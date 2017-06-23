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
            new ItemDePlanilla() { numeroItem = 1, numeroSubItem = 1, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 1, numeroSubItem = 2, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 1, numeroSubItem = 3, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 1, numeroSubItem = 4, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 2, numeroSubItem = 1, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 2, numeroSubItem = 2, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 2, numeroSubItem = 3, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 },
            new ItemDePlanilla() { numeroItem = 3, numeroSubItem = 1, obra = 1557, cantidadParcial = 0.0f, porcentajeParcial = 0.0f, numeroPlanilla = 1 }
        };
    }
}