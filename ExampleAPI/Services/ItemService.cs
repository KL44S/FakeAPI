﻿using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class ItemService
    {
        public static IList<Item> Items = new List<Item>()
        {
            new Item() { numeroItem = 1, obra = 1556, descripcion = "Trabajos preliminares", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 2, obra = 1556, descripcion = "Documentación gráfica, proyecto ejecutivo. Presentación ante orgnaismos oficiales", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 3, obra = 1556, descripcion = "Cartel de obra", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 4, obra = 1556, descripcion = "Paredes", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 5, obra = 1556, descripcion = "Limpieza de obra y obrero", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 6, obra = 1556, descripcion = "Cartel render de obra", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 7, obra = 1556, descripcion = "Obrador, depósitos, sanitarios", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f },
            new Item() { numeroItem = 8, obra = 1556, descripcion = "Cerco de seguridad, pasarelas, señalización", cantidad = 2.0f, pu = 55546.4f, sis = "AA", um = "UN", total = 0.0f, cantidadParcial = 0.0f, porcentajeParcial = 0.0f }
        };
    }
}