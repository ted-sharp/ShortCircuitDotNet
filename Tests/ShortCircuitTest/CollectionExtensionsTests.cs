using Newtonsoft.Json.Linq;
using ShortCircuit.Extensions;

namespace ShortCircuitTest
{
    public class CollectionExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsNullOrEmpty_Null_ReturnTrue()
        {
            ICollection<int>? collection = null;
            Assert.IsTrue(collection.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_Empty_ReturnTrue()
        {
            ICollection<int> collection = new List<int>();
            Assert.IsTrue(collection.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_Any_ReturnFalse()
        {
            ICollection<int> collection = new List<int>() { 1, 2, 3};
            Assert.IsFalse(collection.IsNullOrEmpty());
        }

        [Test]
        public void AddRange_Added3Items_CountIs3()
        {
            ICollection<int> collection1 = new List<int>();
            ICollection<int> collection2 = new List<int>() { 1, 2, 3 };
            collection1.AddRange(collection2);
            Assert.IsTrue(collection1.Count == 3);
        }
    }
}