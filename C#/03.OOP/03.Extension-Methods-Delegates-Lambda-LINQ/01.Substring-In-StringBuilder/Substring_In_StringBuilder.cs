using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Substring_In_StringBuilder
{
    public static StringBuilder Substring(this StringBuilder str, int index, int length)
    {
        if (index >= str.Length || index < 0)
        {
            throw new IndexOutOfRangeException("Index is outside the string.");
        }
        else if ((str.Length-index-length)<=0)
        {
            throw new ArgumentOutOfRangeException("The substring is not in the string length.");
        }
        else if (length<0)
        {
            throw new ArgumentOutOfRangeException("Length must be a zero or positive integer.");
        }
        else
        {
            StringBuilder substring = new StringBuilder();
            substring.Append(str.ToString().Substring(index, length));
            return substring;
        }
    }

    public static StringBuilder Substring(this StringBuilder str, int index)
    {
        if (index >= str.Length || index < 0)
        {
            throw new IndexOutOfRangeException("Index is outside the string.");
        }
        else
        {
            StringBuilder substring = new StringBuilder();
            substring.Append(str.ToString().Substring(index));
            return substring;
        }
    }

    static void Main()
    {
        StringBuilder ala = new StringBuilder();
        ala.Append("rwaytwer6ty");

        Console.WriteLine(ala.Substring(5,3));
        Console.WriteLine(ala.Substring(5));
    }
}