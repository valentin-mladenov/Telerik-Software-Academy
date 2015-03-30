using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueue
{
    public class MyLinkedQueue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;

        public void Enqueue(T data)
        {
            QueueItem<T> newItem = new QueueItem<T>(data);

            if (this.head == null)
            {
                this.head = newItem;
            }
            else if (Count == 1)
            {
                this.tail = newItem;
                this.head.Next = this.tail;
            }
            else
            {
                QueueItem<T> current = this.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newItem;
                this.tail=newItem;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            QueueItem<T> newHead = this.head.Next;
            T dequeuedValue = this.head.Data;
            this.head = newHead;
            this.Count--;
            return dequeuedValue;
        }

        public T PeekFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T peekValue = this.head.Data;
            return peekValue;
        }

        public T PeekLast()
        {
            T peekValue;

            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            if (this.Count == 1)
            {
                peekValue = this.head.Data;
            }
            else
            {
                 peekValue = this.tail.Data;
            }
           
            return peekValue;
        }

        public int Count { get; private set; }
    }
}