using System;

class Print_ASCII_Table
{
    static void Main()
    {
        for (int i = 0; i < 255; i++)
        {
            char symbol = Convert.ToChar(i);
            Console.WriteLine("ASCI code" + i + "->" + symbol);
        }
    }
}