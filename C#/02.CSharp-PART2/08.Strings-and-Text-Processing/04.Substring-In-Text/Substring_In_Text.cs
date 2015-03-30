using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds how many
//times a substring is contained in
//a given text (perform case
//insensitive search).


class Substring_In_Text
{
    static void Main()
    {
        string text = Console.ReadLine();
        string subStr = Console.ReadLine();

        int count = 0;
        int index = -1;

        while (true)
        {
            
            index = text.IndexOf(subStr,index+1);
            if (index == -1)
            {
                break;
            }
            count++;
        }
        Console.WriteLine(count);
    }
}