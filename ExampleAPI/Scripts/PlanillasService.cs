using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Scripts
{
    public class PlanillasService
    {
        public static IList<Planilla> Planillas { get; set; } = new List<Planilla>();
    }
}