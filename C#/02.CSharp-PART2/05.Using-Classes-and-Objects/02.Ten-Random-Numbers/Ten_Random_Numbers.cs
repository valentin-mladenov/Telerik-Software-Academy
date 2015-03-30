using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that generates
//and prints to the console 10
//random values in the range [100, 200].


class Ten_Random_Numbers
{
    static void Main()
    {
        Random numbers = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.Write(numbers.Next(100,200) + " ");
        }
        Console.WriteLine();
    }
}