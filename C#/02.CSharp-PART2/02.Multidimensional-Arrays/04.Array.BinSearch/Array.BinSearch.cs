using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program, that reads from the console
//an array of N integers and an integer K,
//sorts the array and using the method
//Array.BinSearch() finds the largest number
//in the array which is ≤ K. 

class Array_BinSearch
{
    static void Main()
    {
        Console.Write("Numbers in array = ");
        int numbersA = int.Parse(Console.ReadLine());
        Console.Write("Number K = ");
        int numberK = int.Parse(Console.ReadLine());

        int[] arrayN = new int[numbersA];
        int index = 0;
        int largestNumber = 0;

        for (int i = 0; i < arrayN.Length; i++)
        {
            arrayN[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arrayN);

        if (arrayN[0] > numberK)
        {
            Console.WriteLine("All numbers in Array N are bigger than number K.");
        }
        else
        {
            index = Array.BinarySearch(arrayN, numberK);

            if (index >= 0)
            {
                Console.WriteLine("Number K is in array N at {0} place.", index);
            }
            else
            {
                largestNumber = Math.Abs(index) - 1;
                Console.WriteLine("Largest number K in the array N is: {0}", largestNumber);
            }
        }
        //Console.WriteLine(index+ " " + something);
    }
}