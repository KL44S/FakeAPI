using Model;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class ItemValidationObjectGeneratorService
    {
        public static Object GetValidationObject(IDictionary<Item.Attributes, String> ValidationErrors, Item Item)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var ItemValidationObject = new
            {
                obra = new
                {
                    value = Item.RequirementNumber,
                    error = ValidationErrors[Item.Attributes.RequirementNumber]
                },
                numeroItem = new
                {
                    value = Item.ItemNumber,
                    error = ValidationErrors[Item.Attributes.ItemNumber]
                },
                descripcion = new
                {
                    value = Item.Description,
                    error = ValidationErrors[Item.Attributes.Description]
                }
            };

            return ItemValidationObject;
        }
    }
}