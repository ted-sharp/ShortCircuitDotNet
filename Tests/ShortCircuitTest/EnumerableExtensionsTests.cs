using Newtonsoft.Json.Linq;
using ShortCircuit.Extensions;

namespace ShortCircuitTest
{
    public class EnumerableExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsNullOrEmpty_Null_ReturnTrue()
        {
            IEnumerable<int>? enumerable = null;
            Assert.IsTrue(enumerable.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_Empty_ReturnTrue()
        {
            IEnumerable<int> enumerable = Enumerable.Empty<int>();
            Assert.IsTrue(enumerable.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_ListEmpty_ReturnTrue()
        {
            IEnumerable<int> enumerable = new List<int>();
            Assert.IsTrue(enumerable.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_Any_ReturnFalse()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);
            Assert.IsFalse(enumerable.IsNullOrEmpty());
        }

        [Test]
        public void IsSingle_Add1Item_ReturnTrue()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 1);
            Assert.IsTrue(enumerable.IsSingle());
        }

        [Test]
        public void IsSingle_Add2Item_ReturnFalse()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 2);
            Assert.IsFalse(enumerable.IsSingle());
        }

        [Test]
        public void OrEmpty_NullToEmpty_CountIs0()
        {
            IEnumerable<int>? enumerable = null;
            Assert.That(enumerable.OrEmpty().Count(), Is.EqualTo(0));
        }

        [Test]
        public void Paginate_1Page3Items_CountIs3()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 10);
            Assert.That(enumerable.Paginate(3, 1).Count(), Is.EqualTo(3));
        }

        [Test]
        public void ForEach_Sum1to10_Is55()
        {
            int sum = 0;
            Enumerable.Range(1, 10).ForEarch(x => sum += x);
            Assert.That(sum, Is.EqualTo(55));
        }
    }
}