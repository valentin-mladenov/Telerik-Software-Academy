using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert decimal
//numbers to their hexadecimal representation.


class Decimal_To_Hexadesimal
{
    static void Main()
    {
        Console.WriteLine("Please enter a decimal number:");
        int number = int.Parse(Console.ReadLine());

        string hexNumber = number.ToString("X");

        Console.WriteLine("Hexadecimal representation: {0}", hexNumber);
    }
}