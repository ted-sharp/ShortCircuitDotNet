using Newtonsoft.Json.Linq;
using ShortCircuit.Extensions;

namespace ShortCircuitTest
{
    public class DictionaryExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetKey_Empty_IsDefault()
        {
            Dictionary<int, string> dictionary = new();
            Assert.That(dictionary.GetKey("a"), Is.EqualTo(0));
        }

        [Test]
        public void GetKey_A_Is1()
        {
            Dictionary<int, string> dictionary = new() { { 1, "a" } };
            Assert.That(dictionary.GetKey("a"), Is.EqualTo(1));
        }

        [Test]
        public void GetValue_Empty_IsDefault()
        {
            Dictionary<int, string> dictionary = new();
            Assert.That(dictionary.GetValue(0), Is.EqualTo(default(string)));
        }

        [Test]
        public void GetValue_1_IsA()
        {
            Dictionary<int, string> dictionary = new() { { 1, "a" } };
            Assert.That(dictionary.GetValue(1), Is.EqualTo("a"));
        }

        [Test]
        public void AddOrUpdate_Count_Is1()
        {
            Dictionary<int, string> dictionary = new();
            dictionary.AddOrUpdate(1, "a");
            Assert.That(dictionary.Count, Is.EqualTo(1));
        }

        [Test]
        public void TryAddAny_Count_Is0()
        {
            Dictionary<int, string> dictionary = new();
            dictionary.TryAddAny(1, "");
            Assert.That(dictionary.Count, Is.EqualTo(0));
        }

    }
}