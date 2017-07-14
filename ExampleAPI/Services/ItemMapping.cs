using ExampleAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class ItemMapping : MappingService<Item, ItemViewModel>
    {
        public override Item MapViewModel(ItemViewModel ItemViewModel)
        {
            Item Item = new Item();
            Item.Description = ItemViewModel.descripcion;
            Item.ItemNumber = ItemViewModel.numeroItem;
            Item.RequirementNumber = ItemViewModel.obra;

            return Item;
        }

        public override ItemViewModel UnMapEntity(Item Item)
        {
            ItemViewModel ItemViewModel = new ItemViewModel();
            ItemViewModel.obra = Item.RequirementNumber;
            ItemViewModel.numeroItem = Item.ItemNumber;
            ItemViewModel.descripcion = Item.Description;

            return ItemViewModel;
        }
    }
}