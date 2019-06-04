using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindEntityLibrary;
using TeamLibrary.BaseClasses;

namespace TeamLibrary.EntityFrameworkClasses
{
    public class NorthWindDatabaseOperations
    {
        /// <summary>
        /// anonymous objects for join operations
        /// </summary>
        public void Simple()
        {
            var customerIdentifier = 4;
            using (var context = new NorthWindEntities())
            {
                // execute immediately 
                var results = context.Customers
                    .Join(context.Contacts, customer => customer.CustomerIdentifier,contact => contact.ContactId, (customer, ct) => new {Customer = customer, Contact = ct})
                    .FirstOrDefault(item => item.Customer.CustomerIdentifier == customerIdentifier);

                // deferred execution
                var query = from company in context.Customers
                            join contact in context.Contacts on company.ContactId equals contact.ContactId
                            join contactType in context.ContactTypes on contact.ContactId equals contactType.ContactTypeIdentifier
                            where company.CustomerIdentifier == customerIdentifier
                            select new Company
                            {
                                Id = customerIdentifier,
                                Name = company.CompanyName,
                                FirstName =company.Contact.FirstName,
                                LastName = company.Contact.LastName,
                                Title = company.ContactType.ContactTitle
                            };

                var test = query.FirstOrDefault();
                Console.WriteLine();
            }
        }
    }
}
