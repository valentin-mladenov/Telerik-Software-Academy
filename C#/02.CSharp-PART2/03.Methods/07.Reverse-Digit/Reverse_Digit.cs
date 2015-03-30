using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that reverses the
//digits of given decimal number.
//Example: 256  652


class Reverse_Digit
{
    static string ReverseNumber(string number)
    {
        char[] digitName = number.ToCharArray();
        int revLenght = digitName.Length;
        char[] reversedArray = new char[revLenght];

        for (int i = 0; i < digitName.Length; i++)
        {
            reversedArray[i] = digitName[revLenght - 1 - i];
        }

        string finish = string.Join("", reversedArray);
        return finish;
    }

    static void Main()
    {
        Console.Write("Enter a Number:");
        string number = Console.ReadLine();

        Console.WriteLine("The reversed number is: {0}", ReverseNumber(number));
    }
}