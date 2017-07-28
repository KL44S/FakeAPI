using ExampleAPI.Models;
using Model;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SheetMappingService : MappingService<Sheet, PlanillaViewModel>
    {
        private ISheetService _sheetService;

        public SheetMappingService()
        {
            this._sheetService = new SheetService();
        }

        public override Sheet MapViewModel(PlanillaViewModel ViewModel)
        {
            Sheet Sheet = new Sheet();
            Sheet.FromDate = ViewModel.fechaDesde;
            Sheet.RequirementNumber = ViewModel.obra;
            Sheet.SheetNumber = ViewModel.numeroPlanilla;
            Sheet.SheetStateId = ViewModel.codigoDeEstado;
            Sheet.UntilDate = ViewModel.fechaHasta;

            return Sheet;
        }

        private int GetExpirationStateId(Sheet Sheet)
        {
            ExpirationState ExpirationState = this._sheetService.GetExpirationStateFromSheet(Sheet);

            return ExpirationState.ExpirationStateId;
        }

        public override PlanillaViewModel UnMapEntity(Sheet Sheet)
        {
            PlanillaViewModel PlanillaViewModel = new PlanillaViewModel();
            PlanillaViewModel.codigoDeEstado = Sheet.SheetStateId;
            PlanillaViewModel.fechaDesde = Sheet.FromDate;
            PlanillaViewModel.fechaHasta = Sheet.UntilDate;
            PlanillaViewModel.numeroPlanilla = Sheet.SheetNumber;
            PlanillaViewModel.obra = Sheet.RequirementNumber;
            PlanillaViewModel.codigoDeEstadoDeExpiracion = this.GetExpirationStateId(Sheet);

            return PlanillaViewModel;
        }
    }
}