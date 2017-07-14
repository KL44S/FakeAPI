using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        public enum Attributes { RequirementNumber, ItemNumber, Description };

        public int RequirementNumber { get; set; }
        public int ItemNumber { get; set; }
        public String Description { get; set; }
    }
}
