namespace SortingAlgo.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class MergeSorterUnitTest
    {
        [TestMethod]
        public void MergeSorterTestInteger()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new MergeSorter<int>());
            var result = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void MergeSorterTestString()
        {
            var collection = new SortableCollection<string>(new[] { "22", "AA", "11", "101", "33", "0", "101" });
            collection.Sort(new MergeSorter<string>());
            var result = new SortableCollection<string>(new[] { "0", "101", "101", "11", "22", "33", "AA" });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void MergeSorterTestChars()
        {
            var collection = new SortableCollection<char>(new[] { '2', 'A', '1', '0', '3', '0', '&' });
            collection.Sort(new MergeSorter<char>());
            var result = new SortableCollection<char>(new[] { '&', '0', '0', '1', '2', '3', 'A' });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void MergeSorterTestDecimals()
        {
            var collection = new SortableCollection<decimal>(new[] { 22M, -11.2M, 101.1M, 33M, 0.3M, 101M });
            collection.Sort(new MergeSorter<decimal>());
            var result = new SortableCollection<decimal>(new[] { -11.2M, 0.3M, 22M, 33M, 101M, 101.1M });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }

        [TestMethod]
        public void MergeSorterTestBool()
        {
            var collection = new SortableCollection<bool>(new[] { true, false, true, false, true, false });
            collection.Sort(new MergeSorter<bool>());
            var result = new SortableCollection<bool>(new[] { false, false, false, true, true, true, });
            for (int i = 0; i < result.Items.Count; i++)
            {
                Assert.AreEqual(collection.Items[i], result.Items[i]);
            }
        }
    }
}
