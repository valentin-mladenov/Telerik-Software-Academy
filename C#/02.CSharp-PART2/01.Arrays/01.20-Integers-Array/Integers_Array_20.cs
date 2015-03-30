using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that allocates array of 20 integers
//and initializes each element by its index multiplied
//by 5. Print the obtained array on the console.



class Integers_Array_20
{
    static void Main()
    {
        int[] array20 = new int[20];

        for (int i = 0; i < array20.Length; i++)
        {
            array20[i] = i * 5;
        }

        string array20Product5 = string.Join(", ", array20);
        Console.WriteLine(array20Product5);
    }
}