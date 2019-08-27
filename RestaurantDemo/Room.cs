namespace RestaurantDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Guests = new HashSet<Guest>();
        }

        [Key]
        public int RoomIdentifier { get; set; }

        public int? RoomFloor { get; set; }

        [StringLength(1)]
        public string RoomDesginator { get; set; }

        public int? RoomNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
