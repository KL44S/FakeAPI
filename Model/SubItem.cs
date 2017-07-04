using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SubItem
    {
        public int RequirementNumber { get; set; }
        public int ItemNumber { get; set; }
        public int SubItemNumber { get; set; }
        public String Description { get; set; }
        public String Sis { get; set; }
        public float UnitPrice { get; set; }
        public String UnitOfMeasurement { get; set; }
        public float TotalQuantity { get; set; }
    }
}
