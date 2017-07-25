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
        public static Object GetValidationObject(IDictionary<Attributes.Requirement, String> ValidationErrors, Requirement Requirement)
        {
            MessageService.FillErrorMessages(ValidationErrors);

            var RequirementValidationObject = new
            {
                obra = new
                {
                    value = Requirement.RequirementNumber,
                    error = ValidationErrors[Attributes.Requirement.RequirementNumber]
                },
                oco = new
                {
                    value = Requirement.PurchaseOrder,
                    error = ValidationErrors[Attributes.Requirement.PurchaseOrder]
                },
                ejercicioOco = new
                {
                    value = Requirement.PurchaseOrderExcercise,
                    error = ValidationErrors[Attributes.Requirement.PurchaseOrderExcercise]
                },
                proveedor = new
                {
                    value = Requirement.Provider,
                    error = ValidationErrors[Attributes.Requirement.Provider]
                },
                diasDeCertificacion = new
                {
                    value = Requirement.CertificationDays,
                    error = ValidationErrors[Attributes.Requirement.CertificationDays]
                },
            };

            return RequirementValidationObject;
        }
    }
}