using System;

    //Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 -> value=1.
    class Bit_Number_In_Integer
    {
        static void Main()
        {
            Console.WriteLine("Enter a number:");
            int integerI = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a bit position:");
            int position = int.Parse(Console.ReadLine());
            int mask = integerI >> position;
            int numberV = mask & 1;
            if (numberV == 1)
                Console.WriteLine("The bit position {1} of number {0} have value of 1", integerI, position);
            else
                Console.WriteLine("The bit position {1} of number {0} have value of 0.", integerI, position);
        }
    }
