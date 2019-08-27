namespace RestaurantDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guest
    {
        [System.Diagnostics.CodeAnalysis
            .SuppressMessage(
                "Microsoft.Usage", 
                "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guest()
        {
            BreakfastOrders = new HashSet<BreakfastOrder>();
        }

        [Key]
        public int GuestIdentifier { get; set; }

        public int? RoomIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis
            .SuppressMessage(
                "Microsoft.Usage", 
                "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BreakfastOrder> BreakfastOrders { get; set; }

        public virtual Room Room { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
