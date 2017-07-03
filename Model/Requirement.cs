﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requirement
    {
        public int RequirementNumber { get; set; }
        public int Oco { get; set; }
        public int OcoExcercise { get; set; }
        public int CertificationDays { get; set; }
        public String Provider { get; set; }
        public IList<String> Cuits { get; set; }
    }
}