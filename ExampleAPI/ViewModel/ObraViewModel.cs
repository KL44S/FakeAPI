﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Models
{
    public class ObraViewModel
    {
        public int id { get; set; }
        public int obra { get; set; }
        public int oco { get; set; }
        public int ejercicioObra { get; set; }
        public String proveedor { get; set; }
        public int diasDeCertificacion { get; set; }
        public DateTime? fechaDeInicio { get; set; }
    }
}