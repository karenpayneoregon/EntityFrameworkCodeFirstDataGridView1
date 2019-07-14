using NorthWindDataLibrary.Helpers;

namespace NorthWindDataLibrary.Classes
{
    /// <summary>
    /// Container for displaying customers in a DataGridView
    /// The Notification change via Bindable will be discussed
    /// in a future article to this article.
    /// </summary>
    public class CustomerEntity : Bindable
    {

        public int CustomerIdentifier { get; set; }

        public string CompanyName
        {
            get => Get<string>();
            set => Set(value);
        }

        public int? ContactIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string CountyName { get; set; }
    }
}