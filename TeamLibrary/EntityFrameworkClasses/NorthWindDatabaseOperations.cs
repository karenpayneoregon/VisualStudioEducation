using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BaseConnectionLibrary.ConnectionClasses;
using NorthWindEntityLibrary;
using QueryLibrary;
using TeamLibrary.BaseClasses;

namespace TeamLibrary.EntityFrameworkClasses
{
    public class NorthWindDatabaseOperations : SqlServerConnection
    {
        /// <summary>
        /// Get customer by primary key, since result is an anonymous type
        /// it can not be used outside of this method.
        /// </summary>
        /// <param name="pIdentifier"></param>
        public void AnonymousCustomer(int pIdentifier)
        {
            using (var context = new NorthWindEntities())
            {
                // execute immediately 
                var results = context.Customers
                    .Join(context.Contacts, customer => customer.CustomerIdentifier, contact => contact.ContactId, 
                        (customer, ct) => new
                        {
                            Customer = customer,
                            Contact = ct
                        })
                    .FirstOrDefault(item => item.Customer.CustomerIdentifier == pIdentifier);

            }
        }
        /// <summary>
        /// Given the method <see cref="AnonymousCustomer"/>
        /// </summary>
        /// <param name="pIdentifier"></param>
        /// <returns></returns>
        public CustomerSpecial NotAnonymousCustomer(int pIdentifier)
        {
            using (var context = new NorthWindEntities())
            {
                // execute immediately 
                return context.Customers
                    .Join(context.Contacts, customer => customer.CustomerIdentifier, contact => contact.ContactId, 
                        (customer, ct) => new CustomerSpecial
                        {
                            Customer = customer,
                            Contact = ct
                        })
                    .FirstOrDefault(item => item.Customer.CustomerIdentifier == pIdentifier);

            }
        }

        public CustomerSpecial GetCustomersByCustomerIdentifierSqlClientDataProvider(int pCustomerIdentifier)
        {
            DatabaseServer = ".\\SQLEXPRESS";
            DefaultCatalog = "NorthWindAzureForInserts";
            var statements = new SelectStatements();

            var customer = new CustomerSpecial()
            {
                Customer = new Customer()
                {
                    Country = new Country(),
                    CustomerIdentifier = pCustomerIdentifier,
                    Contact = new Contact()
                },
                Contact = new Contact()
            };

            using (var cn = new SqlConnection {ConnectionString = ConnectionString})
            {
                using (var cmd = new SqlCommand {Connection = cn})
                {
                    cmd.CommandText = statements.SelectCustomerByCustomerIdentifier;
                    cmd.Parameters.AddWithValue("@CustomerIdentifier", pCustomerIdentifier);
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            customer.Customer.CompanyName = reader.GetString(1);
                            customer.Customer.ContactId = reader.GetInt32(2);
                            customer.Customer.Contact.FirstName = reader.GetString(3);
                            customer.Customer.Contact.LastName = reader.GetString(4);
                            customer.Contact.Title = reader.GetString(5);
                            customer.Customer.Contact.Title = reader.GetString(5);
                            customer.Customer.CountryIdentifier = reader.GetInt32(6);
                            customer.Customer.Country.CountryIdentifier = reader.GetInt32(6);
                            customer.Customer.Country.Name = reader.GetString(7);
                        }
                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                        throw;
                    }

                }
            }


            return customer;
        }
        /// <summary>
        /// Demonstrates
        /// * loading navigation properties
        /// * not loading navigation properties
        ///
        /// done via
        /// context.Configuration.LazyLoadingEnabled = false;
        /// </summary>
        /// <param name="pIdentifier"></param>
        /// <returns></returns>
        public Customer GetCompanyByCustomerIdentifierEager(int pIdentifier)
        {
            /*
             * Country is not null for all - note .Include
             */
            using (var context = new NorthWindEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var test = context.Customers.Include(cust => cust.Country);
                var result1 = test.ToList();
                Console.WriteLine();
            }

            /*
             * NEVER DO THIS even though it works.
             */
            using (var context = new NorthWindEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var test = context.Customers.Include("Country");
                var result1a = test.ToList();
                Console.WriteLine();
            }

            /*
             * Country is not null for all
             */
            using (var context = new NorthWindEntities())
            {
                context.Configuration.LazyLoadingEnabled = true;
                var test = context.Customers;
                var result2 = test.ToList();
                Console.WriteLine();
            }

            /*
             * Country is null for all
             */
            using (var context = new NorthWindEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var test = context.Customers;
                var result3 = test.ToList();
                Console.WriteLine();
            }

            /*
             * Uses default for LazyLoadingEnabled
             */
            using (var context = new NorthWindEntities())
            {
                var test = context.Customers;
                var result4 = test.ToList();
                Console.WriteLine();
            }

            return new Customer();
        }

        public int CountryCountForCustomers(int pCountryCode)
        {


            using (var context = new NorthWindEntities())
            {
                return  context.Entry(context.Countries.Find(pCountryCode))
                    .Collection(item => item.Customers)
                    .Query()
                    .Count();
            }

        }

        /// <summary>
        /// Get customer by primary key, use a custom class to get specific fields.
        /// </summary>
        /// <param name="pIdentifier"></param>
        /// <returns></returns>
        public Company GetCompanyByCustomerIdentifier(int pIdentifier)
        {

            using (var context = new NorthWindEntities())
            {

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
        /// <summary>
        /// Get customer by primary key, get everything except a few properties defined
        /// in partial classes
        /// </summary>
        /// <param name="pIdentifier"></param>
        public void GetCompanyByCustomerIdentifierTemp(int pIdentifier)
        {

            using (var context = new NorthWindEntities())
            {

                // deferred execution
                var query = from company in context.Customers
                    join contact in context.Contacts on company.ContactId equals contact.ContactId
                    join contactType in context.ContactTypes on contact.ContactId equals contactType.ContactTypeIdentifier
                    where company.CustomerIdentifier == pIdentifier
                    select company;


                var results = query.FirstOrDefault();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Get a single customer by primary key using user define class which
        /// has a partial property/field list and a custom Comparer overriding Equals.
        /// </summary>
        /// <param name="pIdentifier">Valid key to locate</param>
        /// <param name="pLog">true to log EF generation to the test output window</param>
        /// <returns>Valid customer if found by primary key</returns>
        public Company GetCompanyWithCountryByIdentifier(int pIdentifier, bool pLog = false)
        {

            using (var context = new NorthWindEntities())
            {
                if (pLog)
                {
                    context.Database.Log = Console.Write;
                }

                // inspect this variable before hitting the line below with FirstOrDefault.
                // talk about using var
                IQueryable<Company> companyQuery = 
                    from company in context.Customers
                    join contact       in context.Contacts       on company.ContactId       equals contact.ContactId
                    join contactType   in context.ContactTypes   on contact.ContactId       equals contactType.ContactTypeIdentifier
                    join country       in context.Customers   on company.CountryIdentifier  equals  country.CountryIdentifier
                    where company.CustomerIdentifier == pIdentifier
                    select new Company
                    {
                        Id = pIdentifier,
                        Name = company.CompanyName,
                        ContactIdentifier =  company.ContactId.Value,
                        FirstName = company.Contact.FirstName,
                        LastName = company.Contact.LastName,
                        Title = company.ContactType.ContactTitle,
                        Country = company.Country.Name,
                        CountryId = company.CountryIdentifier.Value
                    };


                // inspect this line before returning to the caller.
                var result = companyQuery.FirstOrDefault();

                return result;

            }
        }
        /// <summary>
        /// Save a detached customer
        /// </summary>
        /// <param name="pCompany">Company with contact id, contact first and last name</param>
        /// <returns>true successfully updated false on failure</returns>
        public bool UpdateCompanyContactFirstLastName(Company pCompany)
        {
            var contact = new Contact()
            {
                ContactId = pCompany.ContactIdentifier,
                FirstName = pCompany.FirstName,
                LastName = pCompany.LastName
            };

            using (var context = new NorthWindEntities())
            {
                context.Entry(contact).State = EntityState.Modified;
                return context.SaveChanges() == 1;
            }
        }
        /// <summary>
        /// Insert new Customer
        /// </summary>
        /// <param name="pCustomer"></param>
        /// <returns></returns>
        public bool InsertCustomer(Customer pCustomer)
        {
            using (var context = new NorthWindEntities())
            {
                context.Entry(pCustomer).State = EntityState.Added;
                return context.SaveChanges() == 1;
            }
        }
    }
}
