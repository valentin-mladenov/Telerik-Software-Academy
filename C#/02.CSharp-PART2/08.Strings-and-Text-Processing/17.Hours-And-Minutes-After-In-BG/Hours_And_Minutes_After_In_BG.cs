using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Write a program that reads a date and
//time given in the format: day.month.year
//hour:minute:second and prints the date
//and time after 6 hours and 30 minutes
//(in the same format) along with
//the day of week in Bulgarian.


class Hours_And_Minutes_After_In_BG
{
    static string[] daysBG = { "Понеделник", "Вторник", "Сряда", "Четвъртък", "Петък", "Събота", "Неделя" };
    static string[] daysEN = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    static void Main()
    {        
        //DateTime now = DateTime.Now;
        DateTime now = DateTime.Parse("17.01.2014 19:57:30");
        Console.WriteLine(now);

        DateTime result = now.AddHours(6.5);
        string dayBG = "";

        for (int i = 0; i < daysBG.Length; i++)
        {
            if (daysEN[i] == result.DayOfWeek.ToString())
            {
                dayBG = daysBG[i];
            }
        }
        Console.WriteLine(result.ToString()+" "+dayBG);
    }
}