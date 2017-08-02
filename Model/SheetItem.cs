using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SheetItem
    {
        public int RequirementNumber { get; set; }
        public int ItemNumber { get; set; }
        public int SubItemNumber { get; set; }
        public int SheetNumber { get; set; }
        public decimal PartialQuantity { get; set; }
        public decimal PercentQuantity { get; set; }
    }
}
