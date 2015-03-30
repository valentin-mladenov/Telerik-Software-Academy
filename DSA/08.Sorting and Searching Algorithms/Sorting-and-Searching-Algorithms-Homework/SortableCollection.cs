namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private Random random;

        public SortableCollection()
        {
            this.items = new List<T>();
            if (this.random == null)
            {
                this.random = new Random();
            }
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            if (this.random == null)
            {
                this.random = new Random();
            }
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            //// i suppose i should not use this.
            //// return Enumerable.Contains(this.Items, item);

            foreach (var item1 in Items)
            {
                if (item.Equals(item1))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int maxIndex = this.Items.Count;
            int minIndex = 0;
            int midIndex = 0;
            int result;
            while (maxIndex > minIndex)
            {
                midIndex = (maxIndex + minIndex) / 2;
                result = this.Items[midIndex].CompareTo(item);
                if (result < 0)
                {
                    minIndex = midIndex + 1;
                }
                else if (result > 0)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    return true;
                }
            }

            // this is a fix to find if on the first element all other cases throws an exeption
            result = this.Items[midIndex - 1].CompareTo(item);
            if (result == 0)
            {
               return true; 
            }
            return false;
            
        }


        public void Shuffle()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                int randomIndex = this.random.Next(0, this.Items.Count - 1);
                var swap = this.Items[i];
                this.Items[i] = this.Items[randomIndex];
                this.Items[randomIndex] = swap;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
