using ShortCircuit.Extensions;
using ShortCircuit.JaJp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuitTest
{
    public class DateTimeExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2000-10-10", "2000-10-01")]
        public void BeginningOfMonth(DateTime date, DateTime result)
        {
            Assert.That(date.BeginningOfMonth(), Is.EqualTo(result));
        }

        [TestCase("2000-02-01", "2000-02-01 23:59:59.9999999")]
        public void EndOfDay(DateTime date, DateTime result)
        {
            Assert.That(date.EndOfDay(), Is.EqualTo(result));
        }

        [TestCase("2000-02-01", "2000-02-29")]
        [TestCase("2001-02-01", "2001-02-28")]
        [TestCase("2002-12-01", "2002-12-31")]
        public void EndOfMonth(DateTime date, DateTime result)
        {
            Assert.That(date.EndOfMonth(), Is.EqualTo(result));
        }

        [TestCase("2000-01-01", 3, 31, "2000-03-31")]
        [TestCase("2000-12-31", 3, 31, "2001-03-31")]
        [TestCase("2001-01-01", 4, 1, "2001-04-1")]
        public void EndOfTerm(DateTime date, int month, int day, DateTime result)
        {
            Assert.That(date.EndOfTerm(month, day), Is.EqualTo(result));
        }
    }
}
