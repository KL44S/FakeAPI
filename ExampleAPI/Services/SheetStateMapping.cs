using ExampleAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public class SheetStateMapping : MappingService<SheetState, EstadoDePlanillaViewModel>
    {
        public override SheetState MapViewModel(EstadoDePlanillaViewModel EstadoDePlanillaViewModel)
        {
            SheetState SheetState = new SheetState();
            SheetState.Description = EstadoDePlanillaViewModel.descripcion;
            SheetState.SheetStateId = EstadoDePlanillaViewModel.codigoDeEstado;

            return SheetState;
        }

        public override EstadoDePlanillaViewModel UnMapEntity(SheetState SheetState)
        {
            EstadoDePlanillaViewModel EstadoDePlanillaViewModel = new EstadoDePlanillaViewModel();
            EstadoDePlanillaViewModel.codigoDeEstado = SheetState.SheetStateId;
            EstadoDePlanillaViewModel.descripcion = SheetState.Description;

            return EstadoDePlanillaViewModel;
        }
    }
}