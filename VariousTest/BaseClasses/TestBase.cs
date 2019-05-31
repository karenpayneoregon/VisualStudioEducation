using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.Classes;

namespace VariousTest.BaseClasses
{
    public class TestBase
    {
        /// <summary>
        /// Valid person object
        /// </summary>
        public Person2 KarenPayne => new Person2() {FirstName = "Karen", LastName = "Payne", BirthDate = new DateTime(1956, 9, 24) };
    }
}
