namespace _1.PriorityQueueBinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryHeap<T> : ICollection<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] data;
        private int capacity;
        private bool sorted;
        private bool biggestFirst;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                int previousCapacity = this.capacity;
                this.capacity = Math.Max(value, this.Count);
                if (this.capacity != previousCapacity)
                {
                    var innerArr = new T[this.capacity];
                    Array.Copy(this.data, innerArr, this.Count);
                    this.data = innerArr;
                }
            }
        }

        public BinaryHeap(bool biggestFirst = true)
        {
            this.biggestFirst = biggestFirst;
            this.data = new T[DefaultSize];
            this.Capacity = DefaultSize;
        }

        private BinaryHeap(T[] newData, int count)
        {
            this.Capacity = count;
            this.Count = count;
            Array.Copy(this.data, newData, count);
        }

        public T Peek()
        {
            return this.data[0];
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.Capacity];
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity *= 2;
            }

            this.data[this.Count] = item;
            this.UpHeap();
            this.Count++;
        }

        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove item, heap is empty.");
            }

            T result = this.data[0];

            this.Count--;
            this.data[0] = this.data[this.Count];
            this.data[this.Count] = default(T); //Clears the Last Node
            this.DownHeap();

            return result;
        }

        private void UpHeap()
        {
            this.sorted = false;
            int currentCount = this.Count;
            T item = this.data[currentCount];
            int currentParent = this.Parent(currentCount);

            if (this.biggestFirst)
            {
                while (currentParent > -1 && item.CompareTo(this.data[currentParent]) > 0)
                {
                    this.data[currentCount] = this.data[currentParent]; //Swap nodes
                    currentCount = currentParent;
                    currentParent = this.Parent(currentCount);
                }
            }
            else
            {
                while (currentParent > -1 && item.CompareTo(this.data[currentParent]) < 0)
                {
                    this.data[currentCount] = this.data[currentParent]; //Swap nodes
                    currentCount = currentParent;
                    currentParent = this.Parent(currentCount);
                }
            }

            this.data[currentCount] = item;
        }

        private void DownHeap() //helper function that performs down-heap bubbling
        {
            this.sorted = false;
            int node;
            int parent = 0;
            T item = this.data[parent];
            while (true)
            {
                int child1 = this.Child1(parent);
                if (child1 >= this.Count)
                {
                    break;
                }

                int child2 = this.Child2(parent);
                if (child2 >= this.Count)
                {
                    node = child1;
                }
                else
                {
                    node = this.data[child1].CompareTo(this.data[child2]) < 0 ? child1 : child2;
                }
                if (this.biggestFirst)
                {
                    if (item.CompareTo(this.data[node]) < 0)
                    {
                        this.data[parent] = this.data[node]; //Swap nodes
                        parent = node;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (item.CompareTo(this.data[node]) > 0)
                    {
                        this.data[parent] = this.data[node]; //Swap nodes
                        parent = node;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            this.data[parent] = item;
        }

        private void EnsureSort()
        {
            if (this.sorted) return;
            Array.Sort(this.data, 0, this.Count);
            this.sorted = true;
        }

        private int Parent(int index) //helper function that calculates the parent of a node
        {
            return (index - 1) >> 1;
        }

        private int Child1(int index) //helper function that calculates the first child of a node
        {
            return (index << 1) + 1;
        }

        private int Child2(int index) //helper function that calculates the second child of a node
        {
            return (index << 1) + 2;
        }

        public BinaryHeap<T> Copy()
        {
            return new BinaryHeap<T>(this.data, this.Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.EnsureSort();
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            this.EnsureSort();
            return Array.BinarySearch<T>(this.data, 0, this.Count, item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.EnsureSort();
            Array.Copy(this.data, array, this.Count);
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            this.EnsureSort();
            int index = Array.BinarySearch<T>(this.data, 0, this.Count, item);
            if (index < 0)
            {
                return false;
            }

            Array.Copy(this.data, index + 1, this.data, index, this.Count - index);
            this.data[this.Count] = default(T);
            this.Count--;
            return true;
        }
    }
}