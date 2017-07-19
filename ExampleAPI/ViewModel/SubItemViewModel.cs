using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Models
{
    public class SubItemViewModel
    {
        public int numeroItem { get; set; }
        public int numeroSubItem { get; set; }
        public int obra { get; set; }
        public String sis { get; set; }
        public String um { get; set; }
        public float cantidad { get; set; }
        public float pu { get; set; }
        public float total { get; set; }
        public float cantidadParcial { get; set; }
        public float porcentajeParcial { get; set; }
        public String descripcion { get; set; }
    }
}