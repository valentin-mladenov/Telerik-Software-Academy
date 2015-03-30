using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that checks if the
//element at given position in given
//array of integers is bigger than
//its two neighbors (when such exist).


class Bigger_Than_Two_Neighbors
{
    static int[] Array(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static bool BiggerOrNot(int position, int[] array)
    {
        bool bigger = false;

        if ((array[position] > array[position - 1]) && (array[position] > array[position + 1]))
        {
            bigger = true;
        }
        return bigger;
    }

    static void Main()
    {
        Console.Write("Enter how long the array is:");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter a Position:");
        int position = int.Parse(Console.ReadLine());

        int[] array = Array(arrayLength);

        if (position == 0 || position == (array.Length-1))
        {
            Console.WriteLine("Not enoght neighbors (the position is eighter first or last).");
        }
        else
        {
            bool bigger = BiggerOrNot(position, array);

            if (bigger == true)
            {
                Console.WriteLine("The number at position {0} is bigger then it's two neighbors.", position);
            }
            else
            {
                Console.WriteLine("The number at position {0} isn't bigger then it's two neighbors.", position);
            }
        }        
    }
}