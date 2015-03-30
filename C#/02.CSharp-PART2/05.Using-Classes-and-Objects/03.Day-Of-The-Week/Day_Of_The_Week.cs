using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that prints to the
//console which day of the week
//is today. Use System.DateTime.


class Day_Of_The_Week
{
    static void Main()
    {

        Console.Write("Today is ");
        Console.WriteLine(DateTime.Today.DayOfWeek + ".");
    }
}