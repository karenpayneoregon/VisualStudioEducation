using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VariousTest.Traits
{
    public enum Trait
    {
        ValidatingSocialSecurity,
        ObjectsComparer,
        OracleDataProviderRead,
        EntityFrameworkLazingEager,
        ExtensionMethods
    }

    public class TestTraitsAttribute : TestCategoryBaseAttribute
    {
        private Trait[] traits;

        public TestTraitsAttribute(params Trait[] traits)
        {
            this.traits = traits;
        }

        public override IList<string> TestCategories
        {
            get
            {
                var traitStrings = new List<string>();

                foreach (var trait in traits)
                {
                    string value = Enum.GetName(typeof(Trait), trait);
                    traitStrings.Add(value);
                }

                return traitStrings;
            }
        }
    }

}
