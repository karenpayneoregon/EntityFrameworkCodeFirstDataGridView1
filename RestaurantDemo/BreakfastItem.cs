namespace RestaurantDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BreakfastItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BreakfastItem()
        {
            BreakfastOrderItems = new HashSet<BreakfastOrderItem>();
        }

        [Key]
        public int ItemIdentifier { get; set; }

        public string Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BreakfastOrderItem> BreakfastOrderItems { get; set; }
    }
}
