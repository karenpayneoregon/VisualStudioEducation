﻿using System;
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

        protected readonly string[] StringArrayMixedTypesIntegers = { "2", "4B", null, "6", "8A", "", "1.3", "Karen", "-1" };
        protected readonly int[] IntegerArrayValidator = { 2, 0, 0, 6, 0, 0, 0, 0, -1 };
        protected readonly string[] StringArrayAllIntegers = { "2", "4", "5", "6", "8", "12", "1", "99", "-1" };
        protected readonly string[] StringArrayMixedTypesDouble = { "2.4", "4.8'", null, "6.9", "[8.5]", "", "1.3", "Karen", "1" };
        protected readonly string[] StringArrayCurrencyDouble = { "2.4", "4.8'", null, "6.9", "[8.5]", "", "1.3", "Karen", "1" };
        protected readonly double[] DoubleArrayValidator = { 2.4, 0, 0, 6.9, 0, 0, 1.3, 0, 1 };
        protected readonly string[] StringArrayAllDoubles = { "2.6", "4.7", "5", "6", "8.98", "12", "1", "99.2", "-1" };


    }
}
