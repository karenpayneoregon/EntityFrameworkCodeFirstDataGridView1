using System.Windows.Forms;
using Equin.ApplicationFramework;
using NorthWindDataLibrary.Classes;

namespace ReadEditCustomerWithSpecialClass.LanguageExtensions
{
    public static class BindingSourceExtensions
    {
        public static CustomerEntity CurrentCustomerEntity(this BindingSource sender) 
        {
            return ((ObjectView<CustomerEntity>)sender.Current).Object;
        }
    }
}
