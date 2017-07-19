using ExampleAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SubItemMappingService : MappingService<SubItem, SubItemViewModel>
    {
        public override SubItem MapViewModel(SubItemViewModel SubItemViewModel)
        {
            SubItem SubItem = new SubItem();
            SubItem.Description = SubItemViewModel.descripcion;
            SubItem.ItemNumber = SubItemViewModel.numeroItem;
            SubItem.RequirementNumber = SubItemViewModel.obra;
            SubItem.Sis = SubItemViewModel.sis;
            SubItem.SubItemNumber = SubItemViewModel.numeroSubItem;
            SubItem.TotalQuantity = SubItemViewModel.total;
            SubItem.UnitOfMeasurement = SubItemViewModel.um;
            SubItem.UnitPrice = SubItemViewModel.pu;

            return SubItem;
        }

        public override SubItemViewModel UnMapEntity(SubItem SubItem)
        {
            SubItemViewModel SubItemViewModel = new SubItemViewModel();
            SubItemViewModel.total = SubItem.TotalQuantity;
            SubItemViewModel.descripcion = SubItem.Description;
            SubItemViewModel.numeroItem = SubItem.ItemNumber;
            SubItemViewModel.obra = SubItem.RequirementNumber;
            SubItemViewModel.sis = SubItem.Sis;
            SubItemViewModel.numeroSubItem = SubItem.SubItemNumber;
            SubItemViewModel.um = SubItem.UnitOfMeasurement;
            SubItemViewModel.pu = SubItem.UnitPrice;

            return SubItemViewModel;
        }
    }
}