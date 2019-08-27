namespace RestaurantDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BreakfastOrderItem
    {
        [Key]
        public int OrderItemIdentifier { get; set; }

        public int? BreakfastIdentifier { get; set; }

        public int? GuestIdentifier { get; set; }

        public int? Quantity { get; set; }

        public int? ItemIdentifier { get; set; }

        public virtual BreakfastItem BreakfastItem { get; set; }

        public virtual BreakfastOrder BreakfastOrder { get; set; }
    }
}
