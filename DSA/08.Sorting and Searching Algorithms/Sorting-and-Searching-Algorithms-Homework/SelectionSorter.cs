namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    T swap = collection[i];
                    collection[i] = collection[min];
                    collection[min] = swap;
                }
            }
        }
    }
}