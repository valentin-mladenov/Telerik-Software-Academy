using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that returns the
//last digit of given integer as
//an English word. Examples:
//512  "two", 1024  "four",
//12309  "nine".


class Last_Digit_In_English
{
    static string LastDigit(string number)
    {
        char[] digitName = number.ToCharArray();
        int lastDigit = 0;
        string lastDigitName = "";

        for (int i = digitName.Length - 1; i < digitName.Length; i++)
        {
            lastDigit = digitName[i] - 48;
        }

        switch (lastDigit)
        {
            case 0: lastDigitName = "Zero";
                break;
            case 1: lastDigitName = "One";
                break;
            case 2: lastDigitName = "Two";
                break;
            case 3: lastDigitName = "Three";
                break;
            case 4: lastDigitName = "Four";
                break;
            case 5: lastDigitName = "Five";
                break;
            case 6: lastDigitName = "Six";
                break;
            case 7: lastDigitName = "Seven";
                break;
            case 8: lastDigitName = "Eight";
                break;
            case 9: lastDigitName = "Nine";
                break;
        }
        return lastDigitName;
    }

    static void Main()
    {
        Console.Write("Enter a Number:");
        string number = Console.ReadLine();

        Console.WriteLine("The last Digit is {0}", LastDigit(number));
    }
}