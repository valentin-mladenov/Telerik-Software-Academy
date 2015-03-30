using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert binary
//numbers to their decimal representation.


class Binary_To_Decimal
{
    static void Main()
    {
        Console.WriteLine("Please enter a binary number:");
        string number = Console.ReadLine();
        char[] binary = number.ToCharArray();
        Array.Reverse(binary);

        int temp = 0;
        int count = 0;

        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                temp = 1 << i;
                count = temp + count;
            }
        }
        Console.WriteLine("Decimal representation: {0}", count);
    }
}