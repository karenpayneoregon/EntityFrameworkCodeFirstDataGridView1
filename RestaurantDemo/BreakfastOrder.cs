namespace RestaurantDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BreakfastOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BreakfastOrder()
        {
            BreakfastOrderItems = new HashSet<BreakfastOrderItem>();
        }

        [Key]
        public int BreakfastIdentifier { get; set; }

        public int? GuestIdentifier { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OrderDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BreakfastOrderItem> BreakfastOrderItems { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
