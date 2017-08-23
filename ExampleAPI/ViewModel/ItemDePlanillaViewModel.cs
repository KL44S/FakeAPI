using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Models
{
    public class ItemDePlanillaViewModel
    {
        public int numeroItem { get; set; }
        public int numeroSubItem { get; set; }
        public float cantidadParcial { get; set; }
        public float porcentajeParcial { get; set; }
        public float cantidadAcumulada { get; set; }
        public float porcentajeAcumulado { get; set; }
        public int obra { get; set; }
        public int numeroPlanilla { get; set; }
    }
}