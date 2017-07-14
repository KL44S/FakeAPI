﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Models
{
    public class Planilla
    {
        public int obra { get; set; }
        public int numeroPlanilla { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public int codigoDeEstado { get; set; }
    }
}