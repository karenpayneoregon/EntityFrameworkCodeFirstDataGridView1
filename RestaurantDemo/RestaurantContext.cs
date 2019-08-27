namespace RestaurantDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("name=RestaurantContextConnectionString")
        {
        }

        public virtual DbSet<BreakfastItem> BreakfastItems { get; set; }
        public virtual DbSet<BreakfastOrderItem> BreakfastOrderItems { get; set; }
        public virtual DbSet<BreakfastOrder> BreakfastOrders { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreakfastOrder>()
                .HasMany(e => e.BreakfastOrderItems)
                .WithOptional(e => e.BreakfastOrder)
                .WillCascadeOnDelete();
        }
    }
}
