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
        public static Object GetValidationObject(IDictionary<Attributes.Item, String> ValidationErrors, Item Item)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var ItemValidationObject = new
            {
                obra = new
                {
                    value = Item.RequirementNumber,
                    error = ValidationErrors[Attributes.Item.RequirementNumber]
                },
                numeroItem = new
                {
                    value = Item.ItemNumber,
                    error = ValidationErrors[Attributes.Item.ItemNumber]
                },
                descripcion = new
                {
                    value = Item.Description,
                    error = ValidationErrors[Attributes.Item.Description]
                }
            };

            return ItemValidationObject;
        }
    }
}