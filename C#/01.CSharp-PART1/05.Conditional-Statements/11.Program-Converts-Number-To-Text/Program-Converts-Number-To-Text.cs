using System;

//* Write a program that converts a number in the range [0...999] to a text 
//  corresponding to its English pronunciation. Examples:
//    0  "Zero"
//    273  "Two hundred seventy three"
//    400  "Four hundred"
//    501  "Five hundred and one"
//    711  "Seven hundred and eleven"


class Program_Converts_Number_To_Text
{
    public static void Digits(int number0To9)
    {
        switch (number0To9)
        {
            case 0:
                Console.WriteLine("Zero.");
                break;
            case 1:
                Console.WriteLine("One.");
                break;
            case 2:
                Console.WriteLine("Two.");
                break;
            case 3:
                Console.WriteLine("Three.");
                break;
            case 4:
                Console.WriteLine("Four.");
                break;
            case 5:
                Console.WriteLine("Five.");
                break;
            case 6:
                Console.WriteLine("Six.");
                break;
            case 7:
                Console.WriteLine("Seven.");
                break;
            case 8:
                Console.WriteLine("Eight.");
                break;
            case 9:
                Console.WriteLine("Nine.");
                break;
        }
    }
    public static void Teen10To19(int number10To19)
    {
        switch (number10To19)
        {
            case 10:
                Console.WriteLine("Ten");
                break;
            case 11:
                Console.WriteLine("Eleven.");
                break;
            case 12:
                Console.WriteLine("Twelve.");
                break;
            case 13:
                Console.WriteLine("Thirteen.");
                break;
            case 14:
                Console.WriteLine("Fourteen.");
                break;
            case 15:
                Console.WriteLine("Fifteen.");
                break;
            case 16:
                Console.WriteLine("Sixteen.");
                break;
            case 17:
                Console.WriteLine("Seventeen.");
                break;
            case 18:
                Console.WriteLine("Eighteen.");
                break;
            case 19:
                Console.WriteLine("Nineteen.");
                break;
        }
    }

    public static void Tens20To90(int number20To90)
    {
        switch (number20To90)
        {
            case 2:
                Console.Write("Twenty");
                break;
            case 3:
                Console.Write("thirty");
                break;
            case 4:
                Console.Write("Fourty");
                break;
            case 5:
                Console.Write("Fifty");
                break;
            case 6:
                Console.Write("Sixty");
                break;
            case 7:
                Console.Write("Seventy");
                break;
            case 8:
                Console.Write("Eighty");
                break;
            case 9:
                Console.Write("Ninety");
                break;
        }
    }

    public static void Hundreds100To900(int number100To900)
    {
        switch (number100To900)
        {
            case 1:
                Console.Write("One hundred");
                break;
            case 2:
                Console.Write("Two hundred");
                break;
            case 3:
                Console.Write("Three hundred");
                break;
            case 4:
                Console.Write("Four hundred");
                break;
            case 5:
                Console.Write("Five hundred");
                break;
            case 6:
                Console.Write("Six hundred");
                break;
            case 7:
                Console.Write("Seven hundred");
                break;
            case 8:
                Console.Write("Eight hundred");
                break;
            case 9:
                Console.Write("Nine hundred");
                break;
        }
    }

    static void Main()
    {
        int userInput, userFirstDigits, userSecondDigit, userThirdDigit;

        Console.WriteLine("Please enter a number from 0-999:");
        userInput = int.Parse(Console.ReadLine());


        while (userInput < 0 || userInput > 999)
        {
            Console.WriteLine("Error!!! Please enter a valid number.");
            userInput = int.Parse(Console.ReadLine());
        }

        if (userInput >= 0 && userInput <= 9)
        {
            Digits(userInput);
        }

        else if (userInput >= 10 && userInput <= 19)
        {
            Teen10To19(userInput);
        }

        else if (userInput >= 20 && userInput <= 99)
        {
            userFirstDigits = userInput / 10;
            userSecondDigit = userInput - (userFirstDigits * 10);

            if (userSecondDigit == 0)
            {
                Tens20To90(userFirstDigits);
                Console.WriteLine(".");
            }
            else 
            {
                Tens20To90(userFirstDigits);
                Console.Write(" ");
                Digits(userSecondDigit);
            }
        }

        else if (userInput >= 100 && userInput <= 999)
        {
            userFirstDigits = userInput / 100;
            userSecondDigit = ((userInput - (userFirstDigits * 100))/10);
            userThirdDigit = userInput - (userFirstDigits * 100) - (userSecondDigit * 10);

            if (userSecondDigit == 0 && userThirdDigit == 0)
            {
                Hundreds100To900(userFirstDigits);
                Console.WriteLine(".");
            }
            
            else if (userThirdDigit == 0 && userSecondDigit > 2)
            {
                Hundreds100To900(userFirstDigits);
                Console.Write(" and ");
                Tens20To90(userSecondDigit);
                Console.WriteLine(".");
            }

            else if (userSecondDigit == 1)
            {
                Hundreds100To900(userFirstDigits);
                Console.Write(" and ");
                Teen10To19(userThirdDigit + 10);

            }
            else 
            {
                Hundreds100To900(userFirstDigits);
                Console.Write(" and ");
                Tens20To90(userSecondDigit);
                Console.Write(" ");
                Digits(userThirdDigit);
            }
        }
    }
}