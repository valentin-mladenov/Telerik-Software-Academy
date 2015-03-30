using System;
using System.Text;

class Print_9_Copyright_Symbols
{
    static void Main()
    {
        char copyright = '\u00a9';
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("  " + copyright + " ");
        Console.WriteLine(" " + new string(copyright, 3));
        Console.WriteLine(new string(copyright, 5));
    }
}