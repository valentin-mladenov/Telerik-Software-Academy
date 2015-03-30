using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a year
//from the console and checks whether
//it is a leap. Use DateTime.


class Leap_Year_Or_Not
{
    static void Main()
    {
        bool leap = DateTime.IsLeapYear(int.Parse(Console.ReadLine()));

        if (leap == true)
        {
            Console.WriteLine("Is a leap year.");
        }
        else
        {
            Console.WriteLine("Isn't a leap year.");
        }
    }
}