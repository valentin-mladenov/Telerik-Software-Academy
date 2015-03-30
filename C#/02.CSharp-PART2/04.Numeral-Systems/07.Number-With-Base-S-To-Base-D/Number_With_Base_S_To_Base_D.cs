using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert from any
//numeral system of given base s to
//any other numeral system of
//base d (2 ≤ s, d ≤  16).


class Number_With_Base_S_To_Base_D
{

    static string TenTOBaseD(int number, byte bases)
    {

        string str = "";
        char core = 'A';
        int temp = 0;

        while (number > 0)
        {
            temp = number % bases;

            if (temp > 9)
            {
                core = (char)(temp + 55);
            }
            else
            {
                core = (char)(temp + 48);
            }
            str = core + str;
            number = number / bases;

        }
        //Console.WriteLine(str);
        return str;
    }

    static int NumberTo10(string number,byte baseS) 
    {
        string numUp = number.ToUpper();

        char[] numChars = numUp.ToCharArray();
        Array.Reverse(numChars);

        int num10 = 0;
        int temp = 0;

        for (int i = 0; i < numChars.Length; i++)
        {
            if (numChars[i] <= '9')
            {
                temp = numChars[i] - 48;
            }
            else
            {
                temp = numChars[i] - 55;
            }

            if (temp >= baseS)
            {
                return 0;
            }

            num10 = num10 + temp * (int)Math.Pow(baseS, i);
        }
        //Console.WriteLine(num10);
        return num10;
    }

    static void Main()
    {
        Console.Write("Please enter the base of the number up to 36: ");
        byte baseS = byte.Parse(Console.ReadLine());
        Console.Write("Please enter the base to convert up to 36: ");
        byte baseD = byte.Parse(Console.ReadLine());
        Console.Write("Please enter the number: ");
        string number = Console.ReadLine();



        int numberTo10 = NumberTo10(number, baseS);

        if (numberTo10 == 0)
        {
            Console.WriteLine("ERROR!!! Some digit is incorrect. Please try again.");
            Main();
        }

        string tenTOBaseD = TenTOBaseD(numberTo10, baseD);
        Console.WriteLine("The number {0} with base {1} converted to base {2} is: {3}", number, baseS, baseD, tenTOBaseD);
    }
}