using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.BaseClasses;
using TeamLibrary.Classes;

namespace VariousTest.BaseClasses
{
    public class TestBase
    {
        /// <summary>
        /// Person object without SSN
        /// </summary>
        public Person KarenPayne => new Person() {FirstName = "Karen", LastName = "Payne", BirthDate = new DateTime(1956, 9, 24) };
    }
}
