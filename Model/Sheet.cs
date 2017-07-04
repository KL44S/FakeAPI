using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sheet
    {
        public int RequirementNumber { get; set; }
        public int SheetNumber { get; set; }
        public int SheetStateId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
    }
}
