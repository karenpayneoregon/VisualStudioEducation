using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Effort;

namespace EntityEffortExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BasicMockButton_Click(object sender, EventArgs e)
        {
            var connection = DbConnectionFactory.CreateTransient();

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.txt");

            var custList = (from cust in File.ReadAllLines(fileName).ToList()
                let parts = cust.Split(',')
                select new Customer()
                {
                    Name = parts[1]
                }).ToList();

            using (EntityContext context = new EntityContext(connection))
            {
                context.Customers.AddRange(custList);
                context.SaveChanges();

                var currentList = context.Customers.ToList();
                Console.WriteLine();
            }


        }
    }
}
