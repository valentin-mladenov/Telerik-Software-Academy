namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = this.MergeSort(collection);
            collection.Clear();
            foreach (var item in sorted)
            {
                collection.Add(item);
            }
        }

        private IEnumerable<T> Merger(IList<T> left, IList<T> right)
        {
            var result = new List<T>(left.Count + right.Count);
            int leftIncrease = 0;
            int rightIncrease = 0;
            while (left.Count > leftIncrease || right.Count > rightIncrease)
            {
                if (left.Count > leftIncrease && right.Count > rightIncrease)
                {
                    if (left[leftIncrease].CompareTo(right[rightIncrease]) <= 0)
                    {
                        result.Add(left[leftIncrease]);
                        leftIncrease++;
                    }
                    else
                    {
                        result.Add(right[rightIncrease]);
                        rightIncrease++;
                    }
                }
                else if (left.Count > leftIncrease)
                {
                    result.Add(left[leftIncrease]);
                    leftIncrease++;
                }
                else if (right.Count > rightIncrease)
                {
                    result.Add(right[rightIncrease]);
                    rightIncrease++;
                }
            }

            return result;
        }

        private IEnumerable<T> MergeSort(IList<T> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            int middle = array.Count / 2;
            var leftArray = new List<T>(middle);
            var rightArray = new List<T>(array.Count - middle);
            for (int i = 0; i < middle; i++)
            {
                leftArray.Add(array[i]);
            }

            for (int i = middle, j = 0; i < array.Count; j++, i++)
            {
                rightArray.Add(array[i]);
            }

            leftArray = this.MergeSort(leftArray).ToList();
            rightArray = this.MergeSort(rightArray).ToList();
            return this.Merger(leftArray, rightArray);
        }
    }
}
