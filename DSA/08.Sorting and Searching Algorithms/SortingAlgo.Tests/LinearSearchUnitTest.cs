namespace SortingAlgo.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class LinearSearchUnitTest
    {
        [TestMethod]
        public void LinearSearchTestInteger()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, -101 });
            var resultTrue = collection.LinearSearch(-101);
            var resultFalse = collection.LinearSearch(1091);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void LinearSearchTestString()
        {
            var collection = new SortableCollection<string>(new[] { "22", "AA", "11", "101", "33", "0", "101" });
            var resultTrue = collection.LinearSearch("AA");
            var resultFalse = collection.LinearSearch("Mincho");
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void LinearSearchTestChars()
        {
            var collection = new SortableCollection<char>(new[] { '2', 'A', '1', '0', '3', '0', '&' });
            var resultTrue = collection.LinearSearch('&');
            var resultFalse = collection.LinearSearch('$');
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void LinearSearchTestDecimals()
        {
            var collection = new SortableCollection<decimal>(new[] { 22M, -11.2M, 101.1M, 33M, 0.3M, 101M });
            var resultTrue = collection.LinearSearch(-11.2M);
            var resultFalse = collection.LinearSearch(1091M);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void LinearSearchTestBool()
        {
            var collection = new SortableCollection<bool>(new[] { true, true, true });
            var resultTrue = collection.LinearSearch(true);
            var resultFalse = collection.LinearSearch(false);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }
    }
}
