using System;

class String_Variable_With_Without_Quote
{
    static void Main(string[] args)
    {
        string quoted = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(quoted);
        string noquote = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(noquote);
    }
}