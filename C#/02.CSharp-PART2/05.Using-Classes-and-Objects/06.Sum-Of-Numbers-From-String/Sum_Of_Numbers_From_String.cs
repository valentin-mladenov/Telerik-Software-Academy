using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//You are given a sequence of positive
//integer values written into a string,
//separated by spaces. Write a function
//that reads these values from given
//string and calculates their sum. 
//Example:
//string = "43 68 9 23 318"  result = 461


class Sum_Of_Numbers_From_String
{
    static void Main()
    {
        string str = Console.ReadLine();
        char[] allNumbers = str.ToCharArray();

        int sum = 0;
        string temp = "";
        StringBuilder join = new StringBuilder();

        for (int i = 0; i < allNumbers.Length; i++)
        {           
            if (allNumbers[i] == ' ')
            {
                temp = join.ToString();
                sum = int.Parse(temp) + sum;
                join.Clear();
                temp = "";
            }
            else
            {
                join.Append(allNumbers[i] - 48);
            }
        }

        temp = join.ToString();
        if ((temp != " ") && (temp != ""))
        {
            sum = int.Parse(temp) + sum;
        }

        Console.WriteLine(sum);
    }
}