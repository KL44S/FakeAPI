using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SubItemService
    {
        public static IList<SubItem> Items = new List<SubItem>()
        {
            new SubItem() { numeroItem = 1, numeroSubItem = 1, obra = 1557, descripcion = "Trabajos preliminares", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 1, numeroSubItem = 2, obra = 1557, descripcion = "Documentación gráfica, proyecto ejecutivo. Presentación ante orgnaismos oficiales", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 1, numeroSubItem = 3, obra = 1557, descripcion = "Cartel de obra", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 1, numeroSubItem = 4, obra = 1557, descripcion = "Paredes", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 2, numeroSubItem = 1, obra = 1557, descripcion = "Limpieza de obra y obrero", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 2, numeroSubItem = 2, obra = 1557, descripcion = "Cartel render de obra", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 2, numeroSubItem = 3, obra = 1557, descripcion = "Obrador, depósitos, sanitarios", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new SubItem() { numeroItem = 3, numeroSubItem = 1, obra = 1557, descripcion = "Cerco de seguridad, pasarelas, señalización", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 4.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f }
        };
    }
}