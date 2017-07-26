using Model;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SubItemValidationObjectGeneratorService
    {
        public static Object GetValidationObject(IDictionary<Attributes.SubItem, String> ValidationErrors, SubItem SubItem)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var ItemValidationObject = new
            {
                descripcion = new
                {
                    value = SubItem.Description,
                    error = ValidationErrors[Attributes.SubItem.Description]
                },
                um = new
                {
                    value = SubItem.UnitOfMeasurement,
                    error = ValidationErrors[Attributes.SubItem.UnitOfMeasurement]
                },
                pu = new
                {
                    value = SubItem.UnitPrice,
                    error = ValidationErrors[Attributes.SubItem.UnitPrice]
                },
                total = new
                {
                    value = SubItem.TotalQuantity,
                    error = ValidationErrors[Attributes.SubItem.TotalQuantity]
                }
            };

            return ItemValidationObject;
        }
    }
}