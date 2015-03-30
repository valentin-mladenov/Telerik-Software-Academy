using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two
//dates in the format: day.month.year
//and calculates the number of days between them. 

class Days_In_Between
{
    static void Main()
    {
        Console.WriteLine("Please enter the first date in foramt: dd.mm.yyyy");
        DateTime start = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second date in foramt: dd.mm.yyyy");
        DateTime end = DateTime.Parse(Console.ReadLine());
        
        //DateTime start = DateTime.Parse("22.10.2012");
        //DateTime end = DateTime.Parse("01.10.2012");        

        TimeSpan result;
        if (start > end)
        {
            result = start.Subtract(end);
        }
        else
        {
            result = end.Subtract(start);
        }         
        Console.WriteLine("The days between the two dates are: {0}", result.Days);
    }
}