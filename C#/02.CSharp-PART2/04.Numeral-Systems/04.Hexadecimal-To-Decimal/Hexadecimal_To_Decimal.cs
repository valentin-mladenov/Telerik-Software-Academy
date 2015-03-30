using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//Write a program to convert hexadecimal
//numbers to their decimal representation.


class Hexadecimal_To_Decimal
{
    static void Main()
    {
        Console.WriteLine("Please enter a hexadecimal number:");

        int number = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber);

        Console.WriteLine("Decimal representation: {0}", number);
    }
}