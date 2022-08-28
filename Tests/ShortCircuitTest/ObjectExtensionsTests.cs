using Newtonsoft.Json.Linq;
using ShortCircuit.Extensions;
using System;

namespace ShortCircuitTest
{
    public class ObjectExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("a", "a")]
        [TestCase(1, 1)]
        public void As<T>(object value, T result)
        {
            Assert.That(value.As<T>(), Is.EqualTo(result));
        }

        [TestCase("a", 1, 1)]
        [TestCase(1, "a", "a")]
        public void AsOr<T>(object value, T orValue, T result)
        {
            Assert.That(value.AsOr(orValue), Is.EqualTo(result));
        }

        [TestCase(null, "a", "a")]
        [TestCase(null, 1, 1)]
        public void AsOr_Object(object value, object orValue, object result)
        {
            Assert.That(value.AsOr(orValue), Is.EqualTo(result));
        }

        [TestCase("", "a", "")] // string型 が object型 で呼ばれた場合は null のみ考慮
        [TestCase(1, 2, 1)]
        [TestCase(null, "a", "a")]
        [TestCase(null, 1, 1)]
        public void Or_Object(object value, object orValue, object result)
        {
            Assert.That(value.Or(orValue), Is.EqualTo(result));
        }

        [TestCase("", "a", "a")] // string型 は空も考慮
        [TestCase("a", "b", "a")]
        [TestCase(null, "a", "a")]
        public void Or_String(string value, string orValue, string result)
        {
            Assert.That(value.Or(orValue), Is.EqualTo(result));
        }

        [Test]
        public void In_InputParams_ReturnFalse()
        {
            Assert.IsFalse("a".In("", "b"));
        }

        [Test]
        public void In_InputParams_ReturnTrue()
        {
            Assert.IsTrue("a".In("", "a", "b"));
        }

        [Test]
        public void In_InputIEnumerable_ReturnFalse()
        {
            var values = Enumerable.Range(3, 3);
            Assert.IsFalse(2.In(values));
        }

        [Test]
        public void In_InputIEnumerable_ReturnTrue()
        {
            var values = Enumerable.Range(1, 3);
            Assert.IsTrue(2.In(values));
        }

        [Test]
        public void In_InputIString_ReturnFalse()
        {
            Assert.IsFalse('c'.In("ab"));
        }

        [Test]
        public void In_InputIString_ReturnTrue()
        {
            Assert.IsTrue('c'.In("abc"));
        }

        [TestCase(1, 2, 3)]
        [TestCase("a", "ab", "abc")]
        public void IsBetween_ReturnFalse<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            Assert.IsFalse(value.IsBetween<T>(min, max));
        }

        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 3)]
        [TestCase("a", "0", "a")]
        [TestCase("a", "a", "abc")]
        public void IsBetween_ReturnTrue<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            Assert.IsTrue(value.IsBetween<T>(min, max));
        }

        [TestCase("2000-01-01", "1999-01-01", "1999-12-31")]
        [TestCase("2000-01-01", "2000-01-02", "2000-12-31")]
        public void IsBetween_DateTime_ReturnFalse(DateTime value, DateTime min, DateTime max)
        {
            Assert.IsFalse(value.IsBetween(min, max));
        }

        [TestCase("2000-01-01", "1999-01-01", "2000-01-01")]
        [TestCase("2000-01-01", "2000-01-01", "2000-01-03")]
        public void IsBetween_DateTime_ReturnTrue(DateTime value, DateTime min, DateTime max)
        {
            Assert.IsTrue(value.IsBetween(min, max));
        }
    }
}