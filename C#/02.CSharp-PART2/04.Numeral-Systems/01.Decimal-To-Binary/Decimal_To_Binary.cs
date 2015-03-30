using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert decimal
//numbers to their binary representation.


class Decimal_To_Binary
{
    static void Main()
    {
        Console.WriteLine("Please enter a decimal number:");
        int number = int.Parse(Console.ReadLine());
        string str = "";

        while (number > 0)
        {

            str = (number & 1) + str;
            number = number >> 1;

        }

        Console.WriteLine("Binary representation: {0}", str);
    }
}