using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the sequence
//of maximal sum in given array. Example:
//{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//Can you do it with only one loop (with
//single scan through the elements of the array)?


class Max_Sum_Sequence_In_Array
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[] array = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }


        int currentSum = 0;
        int bestSum = int.MinValue;

        StringBuilder bestSequenceBuild = new StringBuilder();

        string bestSequnce = "";

        for (int i = 0; i < array.Length; i++)
        {
            currentSum = currentSum + array[i];
            bestSequenceBuild.AppendFormat("{0} ", array[i]);
            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestSequnce = bestSequenceBuild.ToString();
            }
            if (currentSum < 0)
            {
                currentSum = 0;
                bestSequenceBuild.Clear();
            }
        }
        Console.WriteLine("The best sequence is: \" {0} \" ", bestSequnce);
        Console.WriteLine("The best sum is: {0} ", bestSum);
    }
}