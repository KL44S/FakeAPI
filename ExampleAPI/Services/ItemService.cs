using ExampleAPI.Models;
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
            new Item() { numeroItem = 1, obra = 1557, descripcion = "ALGO" },
            new Item() { numeroItem = 2, obra = 1557, descripcion = "OTRA COSA" },
            new Item() { numeroItem = 3, obra = 1557, descripcion = "YYY OTRA" }
        };
    }
}