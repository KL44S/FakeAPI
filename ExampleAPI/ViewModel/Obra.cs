using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Models
{
    public class Obra
    {
        public int id { get; set; }
        public int obra { get; set; }
        public int oco { get; set; }
        public int ejercicioObra { get; set; }
        public int diasCertificacion { get; set; }
        public String proveedor { get; set; }
        public IList<String> cuits { get; set; }
    }
}