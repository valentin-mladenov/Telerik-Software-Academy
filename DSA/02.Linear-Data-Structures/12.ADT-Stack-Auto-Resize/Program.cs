// Implement the ADT stack as auto-resizable array.
// Resize the capacity on demand (when no space is
// available to add / insert a new element).

namespace _12.ADT_Stack_Auto_Resize
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> testStack = new MyStack<int>();
            //test Push
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            testStack.Push(5);
            testStack.Print();

            //test auto-resize
            testStack.Push(6);
            testStack.Print();
            //test Pop
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Pop());
            testStack.Print();
            //test Peek
            Console.WriteLine(testStack.Peek());
            testStack.Pop();
            Console.WriteLine(testStack.Peek());
        }
    }
}
