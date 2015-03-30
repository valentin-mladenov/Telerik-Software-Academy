using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that adds two positive
//integer numbers represented as arrays
//of digits (each array element arr[i]
//contains a digit; the last digit is
//kept in arr[0]). Each of the numbers
//that will be added could have up to
//10 000 digits.


class My_Big_Integer
{
    static string MyBigInteger(string numberOne,string numberTwo)
    {
        char[] CharArrayOne = numberOne.ToCharArray();
        int revLenght1 = CharArrayOne.Length;
        char[] CharArrayTwo = numberTwo.ToCharArray();
        int revLenght2 = CharArrayTwo.Length;

        //Reverseing the BigIntegers arrays.
        int revLenghtMax = Math.Max(revLenght1, revLenght2) + 1; //It is plus one coz the sum can be bigger.
        int[] reversedArrayOne = new int[revLenghtMax];
        int[] reversedArrayTwo = new int[revLenghtMax];

        for (int i = 0; i < revLenght1; i++)
        {
            reversedArrayOne[i] = CharArrayOne[revLenght1 - 1 - i] - 48; //From char to int.
        }

        for (int i = 0; i < revLenght2; i++)
        {
            reversedArrayTwo[i] = CharArrayTwo[revLenght2 - 1 - i] - 48; //From char to int.
        }

        //Calculating the big integers.
        int[] sumOnePlusTwo = new int[revLenghtMax];
        int reminder = 0;

        for (int j = 0; j < sumOnePlusTwo.Length; j++)
        {
            if (reversedArrayOne[j] + reversedArrayTwo[j] + reminder >= 10)
            {
                sumOnePlusTwo[j] = (reversedArrayOne[j] + reversedArrayTwo[j] + reminder) - 10;
                reminder = 1;
            }
            else
            {
                sumOnePlusTwo[j] = reversedArrayOne[j] + reversedArrayTwo[j] + reminder;
                reminder = 0;
            }
        }

        //Reversing back to original state.
        int[] revOnePlusTwo = new int[revLenghtMax];

        for (int i = 0; i < revOnePlusTwo.Length; i++)
        {
            revOnePlusTwo[i] = sumOnePlusTwo[revLenghtMax - 1 - i];
        }

        if (revOnePlusTwo[0] == 0) //If the number is with the original lenght.
        {
            int[] originalLenght = revOnePlusTwo.Skip(1).ToArray();
            string finish = string.Join("", originalLenght);
            return finish;
        }
        else
        {
            string finish = string.Join("", revOnePlusTwo);
            return finish;
        }
    }

    static void Main()
    {
        Console.Write("Enter a Number:");
        string numberA = Console.ReadLine();
        Console.Write("Enter a Number:");
        string numberB = Console.ReadLine();

        Console.WriteLine("The sum of the two numbers is: \n{0}", MyBigInteger(numberA, numberB));
    }
}