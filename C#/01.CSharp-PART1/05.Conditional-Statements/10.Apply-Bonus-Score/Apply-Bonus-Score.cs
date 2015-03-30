using System;

//Write a program that applies bonus scores to given scores in the range [1..9].
//he program reads a digit as an input. If the digit is between 1 and 3, the 
//program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
//if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value
//is not a digit, the program must report an error.

//Use a switch statement and at the end print the calculated new value in the console.


class Apply_Bonus_Score
{
    static void Main()
    {
        Console.WriteLine("Please enter a digit (0-9):");
        string userInput = (Console.ReadLine());
        ushort digit;
        bool notADigit = ushort.TryParse(userInput, out digit);

        if (notADigit)
        {
            switch (digit)
            {
                case 0:
                    Console.WriteLine("Error!!! The digit is Zero.");
                    break;
                case 1:
                case 2:
                case 3:
                    Console.WriteLine(digit * 10);
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine(digit * 100);
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine(digit * 1000);
                    break;
                default: 
                    Console.WriteLine("Error!!! More than one digit."); 
                    break;
            }
        }
        else
        {
            Console.WriteLine("Error!!! Not a digit.");
        }
    }
}