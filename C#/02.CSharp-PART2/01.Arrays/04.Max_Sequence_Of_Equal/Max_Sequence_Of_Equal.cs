using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the maximal
//sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.


class Max_Sequence_Of_Equal
{
    static void Main()
    {
        Console.Write("Enater size of Array: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("Array1 [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int result = 1;
        int count = 0;
        int currentMaxResult = 0;
        int countTemp = 0;

        for (int i = 0; i < array.Length-1; i++)
        {
            if (array[i] == array[i + 1])
            {
                result++;
                count = array[i]; 
            }
            else 
            {
                if (currentMaxResult >= result)
                {                  
                }
                else
                {
                currentMaxResult = result;
                countTemp = array[i];
                result = 1;   
                }
            }
        }

        if (currentMaxResult <= result)
        {
            Console.WriteLine("Element: {0}, Repeats: {1} times.", count, result);
        }
        else
	    {
            Console.WriteLine("Element: {0}, Repeats: {1} times.", countTemp, currentMaxResult);
	    }
    }
}