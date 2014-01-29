using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PredicateExtensions;

namespace PredicateExtensionTests
{
    [TestClass]
    public class PredicateExtensionTests
    {
        private static Predicate<int> _greaterThan5Predicate = (x => x > 5);
        private static Predicate<int> _evenPredicate = (x => x % 2 == 0);

        private static Predicate<int> _accPredicate = _evenPredicate + _greaterThan5Predicate;


        [TestMethod]
        public void AllExtensionTest()
        {
            Assert.IsTrue(_accPredicate.All(6));
            Assert.IsFalse(_accPredicate.All(5));
            Assert.IsFalse(_accPredicate.All(7));

            Assert.IsTrue(_evenPredicate.All(6));
            Assert.IsFalse(_evenPredicate.All(5));

            Assert.IsTrue(_greaterThan5Predicate.All(6));
            Assert.IsFalse(_greaterThan5Predicate.All(5));
        }

        [TestMethod]
        public void AnyExtensionTest()
        {
            Assert.IsTrue(_accPredicate.Any(7));
            Assert.IsTrue(_accPredicate.Any(4));
            Assert.IsFalse(_accPredicate.Any(5));

            Assert.IsTrue(_evenPredicate.Any(6));
            Assert.IsFalse(_evenPredicate.Any(5));

            Assert.IsTrue(_greaterThan5Predicate.Any(6));
            Assert.IsFalse(_greaterThan5Predicate.Any(5));
        }

        [TestMethod]
        public void NoneExtensionTest()
        {
            Assert.IsFalse(_accPredicate.None(7));
            Assert.IsFalse(_accPredicate.None(4));
            Assert.IsTrue(_accPredicate.None(5));

            Assert.IsFalse(_evenPredicate.None(6));
            Assert.IsTrue(_evenPredicate.None(5));

            Assert.IsFalse(_greaterThan5Predicate.None(6));
            Assert.IsTrue(_greaterThan5Predicate.None(5));
        }

        [TestMethod]
        public void ExtensionsForFilteringTest()
        {
            var xs = new []{1, 2, 3, 4, 5, 6, 7, 8, 9};

            CollectionAssert.AreEqual(xs.Where(_accPredicate.All).ToArray(), new[] { 6, 8 });
            CollectionAssert.AreEqual(xs.Where(_accPredicate.Any).ToArray(), new[] { 2, 4, 6, 7, 8, 9 });
        }

        [TestMethod]
        public void NullDelegateTests()
        {
            Predicate<int> testNUll = null;
            (testNUll + _accPredicate + testNUll).Any(7);
        }
    }
}
