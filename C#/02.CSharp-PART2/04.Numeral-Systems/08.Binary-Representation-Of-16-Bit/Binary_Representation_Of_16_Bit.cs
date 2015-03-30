using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that shows the
//binary representation of given
//16-bit signed integer number
//(the C# type short).


class Binary_Representation_Of_16_Bit
{
    static void Main()
    {
        Console.WriteLine("Please enter a number from -32,768 to 32,767:");
        short number = short.Parse(Console.ReadLine());

        //short binary = 0;

        if (number < 0)
        {
            number = Math.Abs(number);
            number = (short)(32768 - number);
            string binary = "";

            while (number > 0)
            {

                binary = (number & 1) + binary;
                number = (short)(number >> 1);

            }

            while (binary.Length < 15)
            {
                binary = 0 + binary;
            }
            binary = 1 + binary;

            Console.WriteLine("Binary representation: {0}", binary);
        }
        else
        {
            string binary = "";

            while (number > 0)
            {

                binary = (number & 1) + binary;
                number = (short)(number >> 1);

            }

            while (binary.Length <= 15)
            {
                binary = 0 + binary;
            }

            Console.WriteLine("Binary representation: {0}", binary);
        }
    }
}