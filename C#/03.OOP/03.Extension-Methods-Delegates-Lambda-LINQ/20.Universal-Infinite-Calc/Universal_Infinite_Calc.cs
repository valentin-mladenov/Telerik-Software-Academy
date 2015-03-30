using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//* By using delegates develop an universal static method
//to calculate the sum of infinite convergent series with
//given precision depending on a function of its term.
//By using proper functions for the term calculate with
//a 2-digit precision the sum of the infinite series:
//    1 + 1/2 + 1/4 + 1/8 + 1/16 + …
//    1 + 1/2! + 1/3! + 1/4! + 1/5! + …
//    1 + 1/2 - 1/4 + 1/8 - 1/16 + … 

class Universal_Infinite_Calc
{
    public delegate double UniversalCalc(Func<int, double> term, double precision);

    public class Calculator
    {
        static double Calculation(Func<int, double> term, double precision)
        {
            double sum = 0;
            double temp = 1;
            int count = 0;
            while (Math.Abs(temp) > precision)
            {
                temp = term(count);
                sum += temp;
                count++;
            }
            return sum;
        }

        static double Factorial(int num)
        {
            double fact = 1;
            while (num > 1)
            {
                fact *= num;
                num--;
            }
            return fact; 
        }

        static void Main()
        {
            double precision = 0.01;
            UniversalCalc delegat = new UniversalCalc(Calculation);

            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + ... = {0}", Math.Round(delegat(i => 1.0 / Math.Pow(2, i), precision), 2));
            Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + ... = {0}", Math.Round(delegat(i => 1.0 / Factorial(i + 1), precision), 2));
            Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + ... = {0}", Math.Round(delegat(i => i == 0 ? 1 : -1.0 / Math.Pow(-2, i), precision), 2));
        }
    }
}