using ExampleAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class RequirementMappingService : MappingService<Requirement, ObraViewModel>
    {
        public override Requirement MapViewModel(ObraViewModel ObraViewModel)
        {
            Requirement Requirement = new Requirement();
            Requirement.RequirementNumber = ObraViewModel.obra;
            Requirement.PurchaseOrder = ObraViewModel.oco;
            Requirement.PurchaseOrderExcercise = ObraViewModel.ejercicioObra;
            Requirement.Provider = ObraViewModel.proveedor;
            Requirement.CertificationDays = ObraViewModel.diasDeCertificacion;
            Requirement.InitDate = ObraViewModel.fechaDeInicio;

            return Requirement;
        }

        public override ObraViewModel UnMapEntity(Requirement Requirement)
        {
            ObraViewModel ObraViewModel = new ObraViewModel();
            ObraViewModel.obra = Requirement.RequirementNumber;
            ObraViewModel.oco = Requirement.PurchaseOrder;
            ObraViewModel.ejercicioObra = Requirement.PurchaseOrderExcercise;
            ObraViewModel.proveedor = Requirement.Provider;
            ObraViewModel.diasDeCertificacion = Requirement.CertificationDays;
            ObraViewModel.fechaDeInicio = Requirement.InitDate;

            return ObraViewModel;
        }
    }
}