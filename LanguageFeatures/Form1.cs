using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageFeatures.Builders;
using LanguageFeatures.Classes;
using LanguageFeatures.Extensions;

namespace LanguageFeatures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        private void SimpleIteratorButton_Click(object sender, EventArgs e)
        {
            var pageSize = 25;
            var items = Enumerable.Range(1, 10).Select(x => x * 2).ToSelectionWith(pageSize).Skip(2).Take(7).ToArray();
            Console.WriteLine(string.Join(",",items));

            foreach (int number in EvenSequence(5, 18))
            {
                Console.WriteLine(number.ToString());
            }
        }

        private void OutSideTheBoxButton_Click(object sender, EventArgs e)
        {
            // create a fixed size array of double, simple method
            double[] balance1 = { 23.0, 24.00, 25.0 };

            Array.Resize(ref balance1, 12);


            // overkill to create a fixed size array of double.
            double[] balance2 = Enumerable.Range(23, 3).Select(Convert.ToDouble).ToArray();

            var dict = new Dictionary<double,string>();

            var dictDaysArray = Enumerable.Range(1, 7)
                .Select(item => new KeyValuePair<double, string>
                    (
                        item, 
                        new DateTime(2019, 5, item).DayOfWeek.ToString())
                    ).ToList();

            dict.AddRange(dictDaysArray);

            double[] array = { 3, 4 };

            array = array.Concat(new[] { 20.8 }).ToArray();
            array = array.Add(12.4);
            Console.WriteLine();
        }

        private void BuildBurger_Click(object sender, EventArgs e)
        {
            var burger = (new BurgerBuilder(14)).AddPepperoni().AddLettuce().AddTomato().Build();
            Console.WriteLine();
        }
        private ClaimRecordBuilder _claimsBuilder;
        private void ClaimRecordBuilder1_Click(object sender, EventArgs e)
        {
            _claimsBuilder = new ClaimRecordBuilder();

            _claimsBuilder
                .Start()
                .SetSocialSecurityNumber("123-12-1234")
                .SetPin("2222").LanguageCode(SpokenLanguageCodes.EN)
                .SetAllDoneCode('N');

            var claimsRecord = _claimsBuilder.Build();

            Console.WriteLine();
        }

        private void ClaimRecordBuilder2_Click(object sender, EventArgs e)
        {
            if (_claimsBuilder is null) return;

            _claimsBuilder.IsDone();
            var claimsRecord= _claimsBuilder.Build();

            Console.WriteLine();

        }

        private void ClaimRecordBuilder3_Click(object sender, EventArgs e)
        {
            if (_claimsBuilder is null) return;

            if (_claimsBuilder.IsReady())
            {
                _claimsBuilder.WriteRecord();
            }
        }
    }
}
