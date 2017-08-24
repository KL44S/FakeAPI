using Model;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SheetItemValidationObjectGeneratorService
    {
        public static Object GetValidationObject(IDictionary<Attributes.SheetItem, String> ValidationErrors, SheetItem SheetItem)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var SheetItemValidationObject = new
            {
                cantidadParcial = new
                {
                    value = SheetItem.PartialQuantity,
                    error = ValidationErrors[Attributes.SheetItem.PartialQuantity]
                },
                porcentajeParcial = new
                {
                    value = SheetItem.PercentQuantity,
                    error = ValidationErrors[Attributes.SheetItem.PercentQuantity]
                }
            };

            return SheetItemValidationObject;
        }
    }
}