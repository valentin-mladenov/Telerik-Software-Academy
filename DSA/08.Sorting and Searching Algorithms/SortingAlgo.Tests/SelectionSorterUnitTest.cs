namespace SortingAlgo.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class SelectionSorterUnitTest
    {
        [TestMethod]
        public void SelectionSorterTestInteger()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new SelectionSorter<int>());
            var result = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void SelectionSorterTestString()
        {
            var collection = new SortableCollection<string>(new[] { "22", "AA", "11", "101", "33", "0", "101" });
            collection.Sort(new SelectionSorter<string>());
            var result = new SortableCollection<string>(new[] { "0", "101", "101", "11", "22", "33", "AA" });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void SelectionSorterTestChars()
        {
            var collection = new SortableCollection<char>(new[] { '2', 'A', '1', '0', '3', '0', '&' });
            collection.Sort(new SelectionSorter<char>());
            var result = new SortableCollection<char>(new[] { '&', '0', '0', '1', '2', '3', 'A' });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void SelectionSorterTestDecimals()
        {
            var collection = new SortableCollection<decimal>(new[] { 22M, -11.2M, 101.1M, 33M, 0.3M, 101M });
            collection.Sort(new SelectionSorter<decimal>());
            var result = new SortableCollection<decimal>(new[] { -11.2M, 0.3M, 22M, 33M, 101M, 101.1M });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void SelectionSorterTestBool()
        {
            var collection = new SortableCollection<bool>(new[] { true, false, true, false, true, false });
            collection.Sort(new SelectionSorter<bool>());
            var result = new SortableCollection<bool>(new[] { false, false, false, true, true, true, });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }
    }
}
