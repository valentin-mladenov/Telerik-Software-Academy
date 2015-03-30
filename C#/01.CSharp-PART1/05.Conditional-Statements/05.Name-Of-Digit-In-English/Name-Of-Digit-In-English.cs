using System;

class Name_Of_Digit_In_English
{
    static void Main()
    {
        Console.WriteLine("Please enter a digit (0-9):");
        int digit = int.Parse(Console.ReadLine());

        switch (digit)
        {
            case 0: 
                Console.WriteLine("The digit is Zero."); 
                break;
            case 1: 
                Console.WriteLine("The digit is One."); 
                break;
            case 2: 
                Console.WriteLine("The digit is Two."); 
                break;
            case 3: 
                Console.WriteLine("The digit is Three."); 
                break;
            case 4: 
                Console.WriteLine("The digit is Four."); 
                break;
            case 5: 
                Console.WriteLine("The digit is  Five."); 
                break;
            case 6: 
                Console.WriteLine("The digit is Six."); 
                break;
            case 7: 
                Console.WriteLine("The digit is Seven."); 
                break;
            case 8: 
                Console.WriteLine("The digit is Eight."); 
                break;
            case 9: 
                Console.WriteLine("The digit is Nine."); 
                break;
            default: 
                Console.WriteLine("More than one or not a digit."); 
                break;
        }
    }
}