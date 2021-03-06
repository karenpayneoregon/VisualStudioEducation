﻿using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer.Utilities;
using System.Linq;
using BaseConnectionLibrary.ConnectionClasses;
using SimpleEntityFrameworkExample;
using System.Data.Entity;
using System.Data.SqlClient;

namespace SimpleEntityFrameworkExampleUnitTestProject.BaseClasses
{
    public class TestBase : SqlServerConnection
    {
        public Customer GetCustomerByIdentifier(int pCustomerIdentifier)
        {
            Customer foundCustomer;

            using (var context = new SimpleEntities())
            {
                foundCustomer = context.Customers
                    .FirstOrDefault(customer => customer.CustomerIdentifier == pCustomerIdentifier);
            }

            return foundCustomer;
        }

        public List<Product> GetAllProducts(bool pIncludeTheKitchenSink )
        {
            using (var context = new SimpleEntities())
            {
                return pIncludeTheKitchenSink
                    ? context.Products
                        .Include(prod => prod.Category.Products.Select(product => product.Category))
                        .ToList()
                    : context.Products
                        .Include(prod => prod.Category)
                        .ToList();
            }
        }

        public string GetCustomerNameByIdentifierUsingDataProvider(int pCustomerIdentifier)
        {
            DatabaseServer = ".\\SQLEXPRESS";
            DefaultCatalog = "OrderingRows1";

            var selectStatement = "SELECT CompanyName " + 
                                  "FROM dbo.Customers " +
                                  "WHERE CustomerIdentifier = @CustomerIdentifier;";

            using (var cn = new SqlConnection {ConnectionString = ConnectionString})
            {
                using (var cmd = new SqlCommand {Connection = cn, CommandText = selectStatement})
                {
                    cmd.Parameters.AddWithValue("@CustomerIdentifier", pCustomerIdentifier);
                    cn.Open();
                    return Convert.ToString(cmd.ExecuteScalar());
                }
            }
        }

        public string GetCustomerNameByIdentifierUsingEntityFramework_1(int pCustomerIdentifier) 
        {
            Customer foundCustomer;

            using (var context = new SimpleEntities())
            {
                foundCustomer = context.Customers.FirstOrDefault(customer => customer.CustomerIdentifier == pCustomerIdentifier);
            }

            if (foundCustomer != null)
            {
                return foundCustomer.CompanyName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Using ValueTuple
        /// </summary>
        /// <param name="pCustomerIdentifier"></param>
        /// <returns></returns>
        public (string companyName, bool success) GetCustomerNameByIdentifierUsingEntityFramework_2(int pCustomerIdentifier)
        {
            Customer foundCustomer;

            using (var context = new SimpleEntities())
            {
                foundCustomer = context.Customers.FirstOrDefault(customer => customer.CustomerIdentifier == pCustomerIdentifier);
            }

            return foundCustomer != null ? (foundCustomer.CompanyName, true) : (foundCustomer.CompanyName, false);
        }


    }
}