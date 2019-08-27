using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using NorthWindDataLibrary.NorthWindModels;

namespace NorthWindDataLibrary.Classes
{
    public class Operations
    {
        /// <summary>
        /// Context setup in AllCustomers method
        /// </summary>
        private NorthWindAzureContext _context;

        public void Casing()
        {
            using (var context = new NorthWindAzureContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var example = context.Customers
                    .Include(cust => cust.Country)
                    .Include(cust => cust.Contact)
                    .ToList();

                foreach (var customer in example)
                {
                    customer.Country.Customers = null;
                }
            }

        }

        /// <summary>
        /// Get all customers into a custom class suitable for viewing
        /// in a DataGridView which in the form requires special attention
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<CustomerEntity> AllCustomers(NorthWindAzureContext context)
        {
            _context = context;

            var customerData = (
                from customer in context.Customers
                join contactType in context.ContactTypes on customer.ContactTypeIdentifier 
                    equals contactType.ContactTypeIdentifier
                join contact in context.Contacts on customer.ContactId equals contact.ContactId
                select new CustomerEntity
                {
                    CustomerIdentifier = customer.CustomerIdentifier,
                    CompanyName = customer.CompanyName,
                    ContactIdentifier = customer.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    ContactTypeIdentifier = contactType.ContactTypeIdentifier,
                    ContactTitle = contactType.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    CountryIdentifier = customer.CountryIdentifier,
                    CountyName = customer.Country.Name
                }).ToList();

            return customerData;

        }
        public async Task<List<CustomerEntity>> AllCustomersAsync(NorthWindAzureContext context) 
        {
            _context = context;

            var customerData  = await (
                from customer in context.Customers
                join contactType in context.ContactTypes on customer.ContactTypeIdentifier
                    equals contactType.ContactTypeIdentifier
                join contact in context.Contacts on customer.ContactId equals contact.ContactId

                select new CustomerEntity
                {
                    CustomerIdentifier = customer.CustomerIdentifier,
                    CompanyName = customer.CompanyName,
                    ContactIdentifier = customer.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    ContactTypeIdentifier = contactType.ContactTypeIdentifier,
                    ContactTitle = contactType.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    CountryIdentifier = customer.CountryIdentifier,
                    CountyName = customer.Country.Name
                }).Take(10).ToListAsync();

            return customerData;

        }
        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        public List<CountryItem> GetCountries()
        {
            using (var context = new NorthWindAzureContext())
            {

                // indicates not to load Customers
                context.Configuration.LazyLoadingEnabled = false;
                return context.Countries.Select(country => new CountryItem()
                {
                    CountryIdentifier = country.CountryIdentifier,
                    CountyName = country.Name
                }).ToList();
            }
        }
        /// <summary>
        /// Get all contact types
        /// </summary>
        /// <returns></returns>
        public List<ContactType> GetContactTypes()
        {
            using (var context = new NorthWindAzureContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.ContactTypes.ToList();
            }
        }
        /// <summary>
        /// Get all known contacts
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetContacts()
        {
            using (var context = new NorthWindAzureContext())
            {
                // indicates not to load Customers
                context.Configuration.LazyLoadingEnabled = false;
                return context.Contacts.ToList();
            }
        }

        /// <summary>
        /// Remove customer by primary key
        /// </summary>
        /// <param name="pCustomerIdentifier"></param>
        /// <returns></returns>
        /// <remarks>
        /// Discuss cascading delete rules
        ///     - how to check for child table usage
        /// </remarks>
        public bool RemoveCustomer(int pCustomerIdentifier)
        {
            return true;
        }

    }
}

