//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.SqlServerDao.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SheetItem
    {
        public int requirementNumber { get; set; }
        public int itemNumber { get; set; }
        public int subItemNumber { get; set; }
        public int sheetNumber { get; set; }
        public decimal partialQuantity { get; set; }
        public decimal percentQuantity { get; set; }
    
        public virtual Sheet Sheet { get; set; }
        public virtual SubItem SubItem { get; set; }
    }
}
