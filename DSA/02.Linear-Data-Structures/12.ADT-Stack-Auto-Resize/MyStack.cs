using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ADT_Stack_Auto_Resize
{
    class MyStack<T>
    {
        private T[] array;

        public MyStack()
        {
            this.array = new T[4];
            this.Count = 0;
        }

        public MyStack(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("No Negative Stack!");
            }
            this.array = new T[size];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T data)
        {
            if (this.Count == this.array.Length)
            {
                IncreaseStackSize();
            }
            this.array[this.Count++] = data;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop element from empty stack!");
            }
            this.Count--;
            T returnValue = this.array[this.Count];
            this.array[this.Count] = default(T);
            return returnValue;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek element from empty stack!");
            }
            return this.array[this.Count - 1];
        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.array.Length; i++)
            {
                sb.Append(this.array[i] + " ");
            }
            Console.WriteLine(sb.ToString());
        }

        private void IncreaseStackSize()
        {
            var resizedArray = new T[2 * this.array.Length + 1];
            Array.Copy(this.array, resizedArray, this.array.Length);
            this.array = resizedArray;
        }
    }
}
