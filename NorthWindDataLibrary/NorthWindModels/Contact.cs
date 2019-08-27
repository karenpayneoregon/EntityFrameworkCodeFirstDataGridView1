using System.Collections.Generic;
using NorthWindDataLibrary.Classes;

namespace NorthWindDataLibrary.NorthWindModels
{
    public partial class Contact : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            Customers = new HashSet<Customer>();
        }

        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
