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

        [TestCase("2000-10-10", "2000-10-10", 1)]
        [TestCase("2000-10-10", "2001-01-01", 2)]
        [TestCase("2000-10-10", "2001-12-31", 2)]
        [TestCase("2000-10-10", "2002-01-01", 3)]
        public void ToOrdinalAgeOn(DateTime birthDate, DateTime today, int age)
        {
            Assert.That(birthDate.ToOrdinalAgeOn(today), Is.EqualTo(age));
        }

        [TestCase("2000-03-31", "2020-04-01", 21)]
        [TestCase("2000-04-01", "2020-04-01", 20)]
        [TestCase("2001-05-01", "2021-12-31", 20)]
        [TestCase("2001-05-01", "2022-01-01", 20)]
        public void ToFiscalYearAgeOn(DateTime birthDate, DateTime today, int age)
        {
            Assert.That(birthDate.ToFiscalYearAgeOn(today), Is.EqualTo(age));
        }
    }
}
