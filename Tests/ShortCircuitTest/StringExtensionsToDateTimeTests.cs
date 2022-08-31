using Newtonsoft.Json.Linq;
using ShortCircuit.Extensions;
using ShortCircuit.Extensions.StringExtensionsToDateTime;

namespace ShortCircuitTest
{
    public class StringExtensionsToDateTimeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("0001/01/01", "0001-01-01")]
        [TestCase("1970/01/01", "1970-01-01")]
        [TestCase("1999/12/31", "1999-12-31")]
        [TestCase("2000/01/01", "2000-01-01")]
        [TestCase("2038/01/19", "2038-01-19")]
        [TestCase("9999/12/31", "9999-12-31")]
        public void ToDateTime_yyyyMMdd(string dateTime, DateTime result)
        {
            Assert.That(dateTime.ToDateTime(), Is.EqualTo(result));
        }

        [TestCase("1900/01/01 00:00:00", "1900-01-01 00:00:00")]
        [TestCase("1999/12/31 23:59:59.9999999", "1999-12-31 23:59:59.9999999")]
        [TestCase("1999/12/31 23:59:59.99999999", "1999-12-31 23:59:59.99999999")]
        public void ToDateTime_yyyyMMdd_HHmmssfffffff(string dateTime, DateTime result)
        {
            Assert.That(dateTime.ToDateTime(), Is.EqualTo(result));
        }
    }
}