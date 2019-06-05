﻿using System;
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
        public Company GetCompanyByCustomerIdentifier(int pIdentifier)
        {

            using (var context = new NorthWindEntities())
            {
                // execute immediately 
                var results = context.Customers
                    .Join(context.Contacts, customer => customer.CustomerIdentifier,contact => contact.ContactId, (customer, ct) => new {Customer = customer, Contact = ct})
                    .FirstOrDefault(item => item.Customer.CustomerIdentifier == pIdentifier);

                // deferred execution
                var query = from company in context.Customers
                            join contact in context.Contacts on company.ContactId equals contact.ContactId
                            join contactType in context.ContactTypes on contact.ContactId equals contactType.ContactTypeIdentifier
                            where company.CustomerIdentifier == pIdentifier
                            select new Company
                            {
                                Id = pIdentifier,
                                Name = company.CompanyName,
                                FirstName =company.Contact.FirstName,
                                LastName = company.Contact.LastName,
                                Title = company.ContactType.ContactTitle
                            };


                return query.FirstOrDefault();

            }
        }
        public Company GetCompanyWithCountryByIdentifier(int pIdentifier)
        {

            using (var context = new NorthWindEntities())
            {
                /*
                 * Uncomment to see generated SQL in test output window
                 */
                //context.Database.Log = Console.Write;


                var companyQuery = from company in context.Customers
                    join contact       in context.Contacts       on company.ContactId                  equals contact.ContactId
                    join contactType   in context.ContactTypes   on contact.ContactId                  equals contactType.ContactTypeIdentifier
                    join country       in context.Countries      on company.Country.CountryIdentifier  equals  country.CountryIdentifier
                    where company.CustomerIdentifier == pIdentifier
                    select new Company
                    {
                        Id = pIdentifier,
                        Name = company.CompanyName,
                        FirstName = company.Contact.FirstName,
                        LastName = company.Contact.LastName,
                        Title = company.ContactType.ContactTitle,
                        Country = company.Country.Name,
                        CountryId = company.CountryIdentifier.Value
                    };


                return companyQuery.FirstOrDefault();

            }
        }
    }
}
