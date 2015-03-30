using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//You are given an array of strings.
//Write a method that sorts the array
//by the length of its elements
//(the number of characters composing them).


class Lenght_Sorting_Method
{
    static void Main()
    {
        string[] array = { "a", "aaaaa", "aaaawasdawd", "a", "12355asdf", "wdasdwe" };

        int  min;
        string temp;

        //Sorting with "Selection sort". ;)
        for (int i = 0; i < array.Length - 1; i++)
        {
            char[] ArrayI = array[i].ToCharArray();
            min = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                char[] ArrayJ = array[j].ToCharArray();
                char[] ArrayMin = array[min].ToCharArray();
                if (ArrayJ.Length < ArrayMin.Length)
                {
                    min = j;
                }
            }

            temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        string arraySort = string.Join(", ", array);

        Console.WriteLine(arraySort);
    }
}