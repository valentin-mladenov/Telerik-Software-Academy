using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to check if in a
//given expression the brackets are
//put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).


class Correction_Bracket_Check
{
    static char[] operators = { '/', '*', '-', '+', '=' };

    static void Main()
    {
        string expression = Console.ReadLine();

        int countClose = 0;
        int countOpen = 0;
        bool error = false;

        if (expression[0] == ')')
        {
            Console.WriteLine("Bracets are put incorrectly.");
        }
        else
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    countOpen++;
                }
                if (expression[i] == ')')
                {
                    for (int j = 0; j < operators.Length; j++)
                    {
                        if (expression[i-1] == operators[j])
                        {
                            error = true;
                            break;
                        }
                    }
                    if (error == true)
                    {
                        break;
                    }
                    else
                    {
                        countClose++;
                    }
                }
            }
            if ((countClose == countOpen) && (error == false))
            {
                Console.WriteLine("Bracets are put correctly.");
            }
            else
            {
                Console.WriteLine("Bracets are put incorrectly.");
            }
        }
    }
}