// Implement the ADT queue as dynamic linked list.
// Use generics (LinkedQueue<T>) to allow storing
// different data types in the queue

namespace _13.LinkedQueue
{
    using System;

    class Program
    {
        static void Main()
        {
            MyLinkedQueue<int> testQueue = new MyLinkedQueue<int>();
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);
            testQueue.Enqueue(4);
            testQueue.Enqueue(5);
            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Dequeue());
        }
    }
}
