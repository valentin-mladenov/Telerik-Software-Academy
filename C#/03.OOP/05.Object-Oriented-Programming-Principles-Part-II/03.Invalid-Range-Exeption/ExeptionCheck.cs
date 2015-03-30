using System;
using System.Linq;
namespace _03.Invalid_Range_Exeption
{
    public class ExeptionChecking<T>
        where T : IComparable<T>
    {
        public static void ExeptionCheck(T input, T start, T end)
        {
            try
            {
                if (input.CompareTo(start) < 0 || input.CompareTo(end) > 0)
                {
                    throw new InvalidRangeException<T>(input, start, end);
                }
                else
                {
                    Console.WriteLine("In range. ;)");
                }
            }
            catch (InvalidRangeException<T> ireT)
            {
                Console.Error.WriteLine(ireT.ToString());
            }
        }
    }
}
