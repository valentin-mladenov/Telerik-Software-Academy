using System;

            //Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.


class Is_Third_Digit_7
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int isThirdDigit7 = int.Parse(Console.ReadLine());
        int absIsThirdDigit7 = Math.Abs(isThirdDigit7);
        if ((absIsThirdDigit7 / 100) % 10 == 7)
            Console.WriteLine("The third digit is 7.");
        else
            Console.WriteLine("The third digit isn't 7.");
    }
}
