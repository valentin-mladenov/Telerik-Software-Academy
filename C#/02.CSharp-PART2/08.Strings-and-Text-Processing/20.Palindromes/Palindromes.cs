using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that extracts
//from a given text all palindromes,
//e.g. "ABBA", "lamal", "exe".


class Palindromes
{
    static void Main()
    {
        string text = " asehtrtjd mr civic a regasehshj s, a erghsehsaeh shsthsthsths srjh devoved, wreat gseghases ht Malayalam ew taersndf reviver, easgrsd. Wassamassaw wearyhdtjiguj";
        string[] separators = { " ", "\t", ",", "." };
        string[] textArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<string> valid = new List<string>();
        string temp = "";
        StringBuilder tempReverse = new StringBuilder();

        for (int i = 0; i < textArray.Length; i++)
        {
            temp = textArray[i].ToLower();
            char[] charArrReverse = temp.ToCharArray();
            Array.Reverse(charArrReverse);            
            for (int j = 0; j < charArrReverse.Length; j++)
            {
                tempReverse.Append(charArrReverse[j]);
            }            

            if ((temp == tempReverse.ToString()) && (tempReverse.Length > 1))
            {
                valid.Add(textArray[i]);
            }
            tempReverse.Clear();
        }

        foreach (string item in valid)
        {
            Console.WriteLine(item);
        }
    }
}