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
    
    public partial class SubItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubItem()
        {
            this.SheetItem = new HashSet<SheetItem>();
        }
    
        public int requirementNumber { get; set; }
        public int itemNumber { get; set; }
        public int subItemNumber { get; set; }
        public string description { get; set; }
        public string sis { get; set; }
        public decimal unitPrice { get; set; }
        public string unitOfMeasurement { get; set; }
        public decimal totalQuantity { get; set; }
    
        public virtual Item Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SheetItem> SheetItem { get; set; }
    }
}
