namespace SortingAlgo.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class BinarySearchUnitTest
    {
        [TestMethod]
        public void BinarySearchTestInteger()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, -102, 9 });
            collection.Sort(new MergeSorter<int>());
            var resultTrue = collection.BinarySearch(101);
            var resultFalse = collection.BinarySearch(1091);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void BinarySearchTestString()
        {
            var collection = new SortableCollection<string>(new[] { "22", "AA", "11", "101", "33", "0", "101" });
            collection.Sort(new MergeSorter<string>());
            var resultTrue = collection.BinarySearch("AA");
            var resultFalse = collection.BinarySearch("Mincho");
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void BinarySearchTestChars()
        {
            var collection = new SortableCollection<char>(new[] { '2', 'A', '1', '0', '3', '0', '&' });
            collection.Sort(new MergeSorter<char>());
            var resultTrue = collection.BinarySearch('&');
            var resultFalse = collection.BinarySearch('$');
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void BinarySearchTestDecimals()
        {
            var collection = new SortableCollection<decimal>(new[] { 22M, -11.2M, 101.1M, 33M, 0.3M, 101M });
            collection.Sort(new MergeSorter<decimal>());
            var resultTrue = collection.BinarySearch(-11.2M);
            var resultFalse = collection.BinarySearch(1091M);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void BinarySearchTestBool()
        {
            var collection = new SortableCollection<bool>(new[] { true, true, true });
            collection.Sort(new MergeSorter<bool>());
            var resultTrue = collection.BinarySearch(true);
            var resultFalse = collection.BinarySearch(false);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }
    }
}
