using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Epsilon.People;
using Epsilon.Rules;
using Epsilon.Wearables;

namespace Epsilon.Rules.Tests
{
    [TestClass()]
    public class PajamaRuleTests
    {
        [TestMethod()]
        public void CheckPajamasTest()
        {
            PajamaRule rule = new PajamaRule();

            Person person = new Person()
            {
                Wearing = Clothing.Pajamas
            };

            ClothingResponse response = rule.Execute(ref person, Weather.Hot);

            Assert.IsTrue(response.IsSuccessful, "Pajama rule should succeed.");
            Assert.IsFalse(person.IsWearing(Clothing.Pajamas), "Person should not be wearing pajamas.");

            response = rule.Execute(ref person, Weather.Cold);

            Assert.IsFalse(response.IsSuccessful, "Pajama rule a second time should fail.");

            person.Wear(Clothing.Pajamas);

            Assert.IsTrue(person.IsWearing(Clothing.Pajamas), "Person should be wearing pajams again.");

        }
    }
}