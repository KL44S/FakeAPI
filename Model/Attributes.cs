using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Attributes
    {
        public enum Item { RequirementNumber, ItemNumber, Description };
        public enum Requirement { RequirementNumber, PurchaseOrder, PurchaseOrderExcercise, Provider, CertificationDays };
    }
}
