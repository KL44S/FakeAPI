using Model;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class RequirementValidationObjectGeneratorService
    {
        public static Object GetValidationObject(IDictionary<Requirement.Attributes, String> ValidationErrors, Requirement Requirement)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var RequirementValidationObject = new
            {
                obra = new
                {
                    value = Requirement.RequirementNumber,
                    error = ValidationErrors[Requirement.Attributes.RequirementNumber]
                },
                oco = new
                {
                    value = Requirement.PurchaseOrder,
                    error = ValidationErrors[Requirement.Attributes.PurchaseOrder]
                },
                ejercicioOco = new
                {
                    value = Requirement.PurchaseOrderExcercise,
                    error = ValidationErrors[Requirement.Attributes.PurchaseOrderExcercise]
                },
                proveedor = new
                {
                    value = Requirement.Provider,
                    error = ValidationErrors[Requirement.Attributes.Provider]
                },
                diasDeCertificacion = new
                {
                    value = Requirement.CertificationDays,
                    error = ValidationErrors[Requirement.Attributes.CertificationDays]
                },
            };

            return RequirementValidationObject;
        }
    }
}