using System;
using System.Linq;

//Define a class InvalidRangeException<T> that holds information
//about an error condition related to invalid range.
//It should hold error message and a range definition [start … end].
//Write a sample application that demonstrates the InvalidRangeException<int>
//and InvalidRangeException<DateTime> by entering numbers in the range
//[1..100] and dates in the range [1.1.1980 … 31.12.2013].


namespace _03.Invalid_Range_Exeption
{
    class InvalidRangeMain
    {
        static void Main()
        {
            int inputInt = 153;
            DateTime inputDate = DateTime.Parse("20.11.2014");

            int startInt = 1;
            int endInt = 100;
            DateTime starDate = DateTime.Parse("1.1.1980");
            DateTime endDate = DateTime.Parse("31.12.2013");

            ExeptionChecking<int>.ExeptionCheck(inputInt, startInt, endInt);
            ExeptionChecking<DateTime>.ExeptionCheck(inputDate, starDate, endDate);
        }
    }
}