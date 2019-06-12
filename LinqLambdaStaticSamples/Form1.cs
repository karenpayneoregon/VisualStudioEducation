using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqLambdaStaticSamples.Classes;
using LinqLambdaStaticSamples;
using static LinqLambdaStaticSamples.MockedData.MockedData;

namespace LinqLambdaStaticSamples
{
    /// <summary>
    /// See
    /// https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
    /// </summary>
    public partial class Form1 : Form
    {
        private List<Product> productList;
        private List<Customer> customerList;
        private List<string> categoryList;

        public Form1()
        {

            InitializeComponent();

            var (products, customers) = CreateLists();

            productList = products;
            customerList = customers;
            categoryList = productList.Select(p => p.Category).ToList();

        }

        private void NumberLessThanFiveArrayButton_Click(object sender, EventArgs e)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNumbersLinq =
                from number in numbers
                where number < 5
                select number;

            Console.WriteLine($@"  Numbers < 5 LINQ: {string.Join(",", lowNumbersLinq)}");

            var lowNumbersLambda = numbers.Where(number => number < 5);
            Console.WriteLine($@"Numbers < 5 Lambda: {string.Join(",", lowNumbersLambda)}");


        }
        /// <summary>
        /// Where condition against a strong typed list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersInWashingtonButton_Click(object sender, EventArgs e)
        {
            const string stateAbbreviation = "WA";

            var washingtonCustomersLinq =
                from customer in customerList
                where customer.Region == stateAbbreviation
                select customer;

            var washingtonCustomersLambda = customerList.Where(customers => customers.Region == stateAbbreviation);

            Console.WriteLine();
        }
        /// <summary>
        /// Simple group by example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AggregateCheapPriceButton_Click(object sender, EventArgs e)
        {

            var maxCategoryLength = categoryList.Select(item => item.Length).Max(); 
            var categoriesLnqList =
            (
                from prod in productList
                group prod by prod.Category into prodGroup
                select new
                {
                    Category = prodGroup.Key,
                    CheapestPrice = prodGroup.Min(p => p.UnitPrice)
                }).ToList();


            var categoriesLambdaList =
                (
                    productList.GroupBy(prod => prod.Category)
                        .Select(prodGroup => new Grouper
                        { 
                            Category = prodGroup.Key,
                            CheapestPrice = prodGroup.Min(p => p.UnitPrice)
                        })).OrderBy(grouper => grouper.Category).ToList();

            foreach (var category in categoriesLambdaList)
            {
                Console.WriteLine($"{category.Category,16}, {category.CheapestPrice.ToString("c2")}");   
            }
        }
    }
}
