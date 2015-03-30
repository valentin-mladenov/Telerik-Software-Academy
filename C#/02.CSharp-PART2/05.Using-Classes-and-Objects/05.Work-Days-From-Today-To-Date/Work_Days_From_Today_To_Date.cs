using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that calculates the
//number of workdays between today and
//given date, passed as parameter.
//Consider that workdays are all days
//from Monday to Friday except a fixed
//list of public holidays specified
//preliminary as array.


class Work_Days_From_Today_To_Date
{
    static DateTime[] holidays = {   
                                  new DateTime(2014, 5, 6),
                                  new DateTime(2014, 5, 24),
                                  new DateTime(2014, 3, 3),
                                  new DateTime(2014, 4, 17),
                                  new DateTime(2014, 4, 18),
                                  new DateTime(2014, 4, 17),
                                  new DateTime(2014, 5, 1),
                                  new DateTime(2014, 9, 22)
                                  };

    static int Workdays(DateTime endDay)
    {
        DateTime today = DateTime.Today;
        
        //DateTime today = new DateTime(2014,2,1);
        int allDays = (int)(endDay - today).TotalDays;
        int workdays = 0;

        if (today.DayOfWeek == DayOfWeek.Tuesday)
        {
            allDays = allDays - 6;
            workdays = 4;
        }
        else if (today.DayOfWeek == DayOfWeek.Wednesday)
        {
            allDays = allDays - 5;
            workdays = 3;
        }
        else if (today.DayOfWeek == DayOfWeek.Thursday)
        {
            allDays = allDays - 4;
            workdays = 2;
        }
        else if (today.DayOfWeek == DayOfWeek.Friday)
        {
            allDays = allDays - 3;
            workdays = 1;
        }
        else if (today.DayOfWeek == DayOfWeek.Saturday)
        {
            allDays = allDays - 2;
        }
        else if (today.DayOfWeek == DayOfWeek.Sunday)
        {
            allDays = allDays - 1;
        }

        if (endDay.DayOfWeek == DayOfWeek.Saturday)
        {
            allDays = allDays - 1;
        }
        else if (endDay.DayOfWeek == DayOfWeek.Sunday)
        {
            allDays = allDays - 2;
        }

        int leftover = allDays % 7;
        int weeks = (allDays - leftover) / 7;
        workdays = (weeks * 5) + leftover + workdays;        

        foreach (DateTime holiday in holidays)
        {
            if ((today <= holiday && holiday <= endDay) && (holiday.DayOfWeek != DayOfWeek.Saturday || holiday.DayOfWeek != DayOfWeek.Sunday))
            {
                workdays--;
            }
        }


        return workdays;
    }

    static void Main()
    {
        Console.Write("Enter a date DD.MM.YYYY: ");
        DateTime endDay = DateTime.Parse(Console.ReadLine());

        Console.WriteLine(Workdays(endDay));
    }
}