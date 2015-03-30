using System;

            //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class Exchenge_Bits
{
    static void Main()
    {
        Console.WriteLine("Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.");
        Console.WriteLine("Enter a number:");
        uint forExchenge = uint.Parse(Console.ReadLine());

           //int positionBits345 = 3;
            //int maskBits345 = forExchenge >> positionBits345;
            //int valueOfBits345 = maskBits345 & 111;
            //int positionBits242526 = 24;
            //int maskBits242526 = forExchenge >> positionBits242526;
            //int valueOfBits242526 = maskBits242526 & 111;
            //int mask24 = positionBits242526 << valueOfBits242526;
            //int mask3 = positionBits345 << valueOfBits345;
            //int newValueOfBits242526 = 
            //117440568 = 111000000000000000000111000
        
        {
            int positionBit3 = 3;
            uint maskBit3 = (uint) 1 << positionBit3;
            uint maskAndBit3 = forExchenge & maskBit3;
            uint valueOfBit3 = maskAndBit3 >> positionBit3;

            int positionBit24 = 24;
            uint maskBit24 = (uint) 1 << positionBit24;
            uint maskAndBit24 = forExchenge & maskBit24;
            uint valueOfBit24 = maskAndBit24 >> positionBit24;

            int positionBit4 = 4;
            uint maskBit4 = (uint) 1 << positionBit4;
            uint maskAndBit4 = forExchenge & maskBit4;
            uint valueOfBit4 = maskAndBit4 >> positionBit4;

            int positionBit25 = 25;
            uint maskBit25 = (uint) 1 << positionBit25;
            uint maskAndBit25 = forExchenge & maskBit25;
            uint valueOfBit25 = maskAndBit25 >> positionBit25;

            int positionBit5 = 5;
            uint maskBit5 = (uint) 1 << positionBit5;
            uint maskAndBit5 = forExchenge & maskBit5;
            uint valueOfBit5 = maskAndBit5 >> positionBit5;

            int positionBit26 = 26;
            uint maskBit26 = (uint) 1 << positionBit26;
            uint maskAndBit26 = forExchenge & maskBit26;
            uint valueOfBit26 = maskAndBit26 >> positionBit26;
            
            
            {
                uint exchengedValueOfBit24WithBit3;
                if (valueOfBit3 == 1)
                {
                    exchengedValueOfBit24WithBit3 = ((uint)(1 << positionBit24) | forExchenge);
                }
                else
                {
                    exchengedValueOfBit24WithBit3 = ((uint)(~(1 << positionBit24)) & forExchenge);
                }                
                uint exchengedValueOfBit3WithBit24;
                if (valueOfBit24 == 1)
                {
                    exchengedValueOfBit3WithBit24 = ((uint)(1 << positionBit3) | exchengedValueOfBit24WithBit3);
                }
                else
                {
                    exchengedValueOfBit3WithBit24 = ((uint)(~(1 << positionBit3)) & exchengedValueOfBit24WithBit3);
                }
                uint exchengedValueOfBit25WithBit4;
                if (valueOfBit4 == 1)
                {
                    exchengedValueOfBit25WithBit4 = ((uint)(1 << positionBit25) | exchengedValueOfBit3WithBit24);
                }
                else
                {
                    exchengedValueOfBit25WithBit4 = ((uint)(~(1 << positionBit25)) & exchengedValueOfBit3WithBit24);
                }
                uint exchengedValueOfBit4WithBit25;
                if (valueOfBit25 == 1)
                {
                    exchengedValueOfBit4WithBit25 = ((uint)(1 << positionBit4) | exchengedValueOfBit25WithBit4);
                }
                else
                {
                    exchengedValueOfBit4WithBit25 = ((uint)(~(1 << positionBit4)) & exchengedValueOfBit25WithBit4);
                }
                uint exchengedValueOfBit26WithBit5;
                if (valueOfBit5 == 1)
                {
                    exchengedValueOfBit26WithBit5 = ((uint)(1 << positionBit26) | exchengedValueOfBit4WithBit25);
                }
                else
                {
                    exchengedValueOfBit26WithBit5 = ((uint)(~(1 << positionBit26)) & exchengedValueOfBit4WithBit25);
                }
                uint exchengedValueOfBit5WithBit26;
                if (valueOfBit26 == 1)
                {
                    exchengedValueOfBit5WithBit26 = ((uint)(1 << positionBit5) | exchengedValueOfBit26WithBit5);
                }
                else
                {
                    exchengedValueOfBit5WithBit26 = ((uint)(~(1 << positionBit5)) & exchengedValueOfBit26WithBit5);
                }
                Console.WriteLine("The number binary expresion is: \n" + Convert.ToString(forExchenge,2));
                Console.WriteLine("The exchenged number is: {0}", exchengedValueOfBit5WithBit26);
                Console.WriteLine("The binary expression of exchenged number is: \n" + Convert.ToString(exchengedValueOfBit5WithBit26, 2));                
            }
        }
    }
}
