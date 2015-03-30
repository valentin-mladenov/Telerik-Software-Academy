namespace _1.PriorityQueueBinaryHeap
{
    using System;

    internal class PriorityQueue<T>
        where T : IComparable<T>
    {
        private BinaryHeap<T> queue;

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public T Peek()
        {
            return this.queue.Peek();
        }

        public void Clear()
        {
            this.queue.Clear();
        }

        public bool Contains(T value)
        {
            return this.queue.Contains(value);
        }

        public PriorityQueue(bool bigestFirst = true)
        {
            this.queue = new BinaryHeap<T>(bigestFirst);            
        }

        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }

        public T Dequeue()
        {
            return this.queue.Remove();
        }
    }
}