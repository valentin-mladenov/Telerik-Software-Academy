using System;

            //Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

class Find_If_The_Bit_3_Is_1_Or_0
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int theBit3 = int.Parse(Console.ReadLine());
        int position = 3;
        //int mask = 1 << position;
        //int theBit3AndMask = mask & theBit3;
        //int bit3 = theBit3AndMask >> position;
        int mask = theBit3 >> position;
        int bit3 = mask & 1;
        Console.WriteLine("The third bit is: {0}", bit3);
    }
}