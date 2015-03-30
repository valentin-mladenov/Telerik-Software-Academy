using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sorting an array means to arrange its elements in 
//increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest
//element, move it at the first position, find the 
//smallest from the rest, move it at the second position, etc.


class Sort_An_Array_Using_Selection_Sort
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[] array = new int[number];

        int min, temp;

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        string arraySort = string.Join(", ", array);

        Console.WriteLine(arraySort);
    }
}