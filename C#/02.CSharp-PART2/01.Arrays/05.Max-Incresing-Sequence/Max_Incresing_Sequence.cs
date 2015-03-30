using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the maximal
//increasing sequence in an array. 
//Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

class Max_Incresing_Sequence
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
        int maxResult = 0;
        int currentMaxResult = 0;
        int countTemp = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {            
            if ((array[i] + 1) == array[i + 1])
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

        maxResult = Math.Max(result, currentMaxResult);

        if (currentMaxResult <= result)
        {
            int index = count - maxResult + 2;

            for (int i = index; i <= count +1; i++)
            {
                //array[i] = i;
                Console.Write("{0} ", i);
            }
            //string finish = string.Join(", ", array);
            Console.WriteLine();
        }
        else
        {
            int index = countTemp - maxResult + 1;

            for (int i = index; i < countTemp + 1; i++)
            {
                //array[i] = i;
                Console.Write("{0} ", i);
            }
            //string finish = string.Join(", ", array);
            Console.WriteLine();
        }
    }
}