using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;


namespace NorthWindDataLibrary.NorthWindModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthWindAzureContext : DbContext
    {
        public NorthWindAzureContext()
            : base("data source=.\\SQLEXPRESS;initial catalog=NorthWindAzureForInserts;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public NorthWindAzureContext(string pConnectionString) 
            : base(pConnectionString)
        {
            
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Shipper)
                .HasForeignKey(e => e.ShipVia);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is Customer)
            {
                if (entityEntry.CurrentValues.GetValue<string>("CompanyName") == "")
                {
                    var list = new List<DbValidationError>
                    {
                        new DbValidationError("CompanyName","CompanyName is required")
                    };

                    return new DbEntityValidationResult(entityEntry, list);
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }

        //public override int SaveChanges()
        //{
        //    var entities = ChangeTracker
        //        .Entries()
        //        .Where(entry => entry.Entity is BaseEntity && 
        //                        (entry.State == EntityState.Added || 
        //                         entry.State == EntityState.Modified));

        //    foreach (var entity in entities)
        //    {
        //        if (entity.State == EntityState.Added)
        //        {
        //            ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
        //            ((BaseEntity)entity.Entity).UserCreated = Environment.UserName;
        //        }

        //        ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
        //        ((BaseEntity)entity.Entity).UserModified = Environment.UserName;
        //    }

        //    return base.SaveChanges();
        //}
    }


}
