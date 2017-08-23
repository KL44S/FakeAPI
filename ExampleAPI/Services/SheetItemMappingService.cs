using ExampleAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SheetItemMappingService : MappingService<SheetItem, ItemDePlanillaViewModel>
    {
        public override SheetItem MapViewModel(ItemDePlanillaViewModel SheetItemViewModel)
        {
            SheetItem SheetItem = new SheetItem();
            SheetItem.RequirementNumber = SheetItemViewModel.obra;
            SheetItem.ItemNumber = SheetItemViewModel.numeroItem;
            SheetItem.SubItemNumber = SheetItemViewModel.numeroSubItem;
            SheetItem.PartialQuantity = (Decimal)(SheetItemViewModel.cantidadParcial);
            SheetItem.PercentQuantity = (Decimal)(SheetItemViewModel.porcentajeParcial);
            SheetItem.AccumulatedPercent = (Decimal)(SheetItemViewModel.porcentajeAcumulado);
            SheetItem.AccumulatedQuantity = (Decimal)(SheetItemViewModel.cantidadAcumulada);

            return SheetItem;
        }

        public override ItemDePlanillaViewModel UnMapEntity(SheetItem SheetItem)
        {
            ItemDePlanillaViewModel SheetItemViewModel = new ItemDePlanillaViewModel();
            SheetItemViewModel.obra = SheetItem.RequirementNumber;
            SheetItemViewModel.numeroItem = SheetItem.ItemNumber;
            SheetItemViewModel.numeroSubItem = SheetItem.SubItemNumber;
            SheetItemViewModel.porcentajeParcial = (float)SheetItem.PercentQuantity;
            SheetItemViewModel.cantidadParcial = (float)SheetItem.PartialQuantity;
            SheetItemViewModel.porcentajeAcumulado = (float)(SheetItem.AccumulatedPercent);
            SheetItemViewModel.cantidadAcumulada = (float)(SheetItem.AccumulatedQuantity);

            return SheetItemViewModel;

        }
    }
}