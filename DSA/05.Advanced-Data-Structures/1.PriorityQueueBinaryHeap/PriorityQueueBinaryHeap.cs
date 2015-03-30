// Implement a class PriorityQueue<T> based on the data structure "binary heap".

// I got help from internet, but did most of the work myself.
namespace _1.PriorityQueueBinaryHeap
{
    using System;

    class PriorityQueueBinaryHeap
    {
        static void Main()
        {
            PriorityQueue<int> bagOfInts = new PriorityQueue<int>();

            // Reverse Queue the smallest are first.
            // PriorityQueue<int> bagOfInts = new PriorityQueue<int>(false);

            bagOfInts.Enqueue(2);
            bagOfInts.Enqueue(5000000);
            bagOfInts.Enqueue(-5);
            bagOfInts.Enqueue(5);
            bagOfInts.Enqueue(10);
            bagOfInts.Enqueue(3);
            bagOfInts.Enqueue(25);

            Console.WriteLine(bagOfInts.Count);
            int result = bagOfInts.Dequeue();
            Console.WriteLine(result);
            Console.WriteLine(bagOfInts.Count);
        }
    }
}