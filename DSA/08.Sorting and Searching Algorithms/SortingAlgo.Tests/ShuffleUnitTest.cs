// not required made them for fun. :)

namespace SortingAlgo.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class ShuffleUnitTest
    {
        [TestMethod]
        public void BinarySearchTestInteger()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, -102, 9 });
            var itemsString = string.Join(", ", collection.Items);
            collection.Sort(new SelectionSorter<int>());
            collection.Shuffle();
            collection.Shuffle();
            var shuffleString = string.Join(", ", collection.Items);
            Assert.AreNotEqual(itemsString, shuffleString);
        }

        [TestMethod]
        public void BinarySearchTestString()
        {
            var collection = new SortableCollection<string>(new[] { "22", "AA", "11", "101", "33", "0", "101" });
            var itemsString = string.Join(", ", collection.Items);
            collection.Sort(new SelectionSorter<string>());
            collection.Shuffle();
            collection.Shuffle();
            var shuffleString = string.Join(", ", collection.Items);
            Assert.AreNotEqual(itemsString, shuffleString);
        }

        [TestMethod]
        public void BinarySearchTestChars()
        {
            var collection = new SortableCollection<char>(new[] { '2', 'A', '1', '0', '3', '0', '&' });
            var itemsString = string.Join(", ", collection.Items);
            collection.Sort(new SelectionSorter<char>());
            collection.Shuffle();
            collection.Shuffle();
            var shuffleString = string.Join(", ", collection.Items);
            Assert.AreNotEqual(itemsString, shuffleString);
        }

        [TestMethod]
        public void BinarySearchTestDecimals()
        {
            var collection = new SortableCollection<decimal>(new[] { 22M, -11.2M, 101.1M, 33M, 0.3M, 101M });
            var itemsString = string.Join(", ", collection.Items);
            collection.Sort(new SelectionSorter<decimal>());
            collection.Shuffle();
            collection.Shuffle();
            var shuffleString = string.Join(", ", collection.Items);
            Assert.AreNotEqual(itemsString, shuffleString);
        }

        [TestMethod]
        public void BinarySearchTestBool()
        {
            var collection = new SortableCollection<bool>(new[] { true, false, true, false, true, false });
            var itemsString = string.Join(", ", collection.Items);
            collection.Sort(new SelectionSorter<bool>());
            collection.Shuffle();
            collection.Shuffle();
            var shuffleString = string.Join(", ", collection.Items);
            Assert.AreNotEqual(itemsString, shuffleString);
        }
    }
}
