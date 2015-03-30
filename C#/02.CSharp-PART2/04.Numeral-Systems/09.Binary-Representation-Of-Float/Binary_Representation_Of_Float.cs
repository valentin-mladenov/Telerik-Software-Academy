using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*
//Write a program that shows the internal
//binary representation of given 32-bit
//signed floating-point number in IEEE
//754 format (the C# type float). Example:
//-27,25  sign = 1, exponent = 10000011,
//mantissa = 10110100000000000000000.

class Binary_Representation_Of_Float
{
    static void Main()
    {
        float number = float.Parse(Console.ReadLine());
        long convertBitsOfNumber = BitConverter.DoubleToInt64Bits(number);
        long mask = 1;
        long sign = 0;
        string binaryRepresentation = "";
        string exponent;
        string mantisa;

        sign = ((convertBitsOfNumber >> 63) & mask);

        convertBitsOfNumber = (convertBitsOfNumber & (~(mask << 63)));

        while (convertBitsOfNumber != 0)
        {
            binaryRepresentation = (convertBitsOfNumber & 1) + binaryRepresentation;
            convertBitsOfNumber = convertBitsOfNumber >> 1;
        }

        if (number > -2.0f && number < 2.0f)
        {
            exponent = "0";
            exponent += binaryRepresentation.Substring(3, 7);
            mantisa = binaryRepresentation.Substring(10, 23);
        }
        else
        {
            exponent = binaryRepresentation.Substring(0, 1);
            exponent += binaryRepresentation.Substring(4, 7);
            mantisa = binaryRepresentation.Substring(11, 23);
        }

        Console.Write(sign + " ");
        Console.Write(exponent + " ");
        Console.WriteLine(mantisa);
    }
}