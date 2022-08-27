using ShortCircuit.Extensions;
using ShortCircuit.JaJp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuitTest
{
    public class DateTimeExtensionsToAgeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2000-10-10", "2000-10-09", -1)]
        [TestCase("2000-10-10", "2000-10-10", 0)]
        [TestCase("2000-10-10", "2000-10-11", 0)]
        [TestCase("2000-10-10", "2001-10-09", 0)]
        [TestCase("2000-10-10", "2001-10-10", 1)]
        [TestCase("2000-10-10", "2001-10-11", 1)]
        public void ToAgeOn(DateTime birthDate, DateTime today, int age)
        {
            Assert.That(birthDate.ToAgeOn(today), Is.EqualTo(age));
        }
    }
}
