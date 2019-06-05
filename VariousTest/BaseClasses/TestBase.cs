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
        public Company AroundTheHorn => new Company()
        {
            Id = 4,
            Name = "Around the Horn",
            FirstName = "Thomas",
            LastName = "Hardy",
            Title = "Sales Representative"
        } ;

        /// <summary>
        /// Person object without SSN
        /// </summary>
        public Person KarenPayne => new Person() {FirstName = "Karen", LastName = "Payne", BirthDate = new DateTime(1956, 9, 24) };
    }
}
