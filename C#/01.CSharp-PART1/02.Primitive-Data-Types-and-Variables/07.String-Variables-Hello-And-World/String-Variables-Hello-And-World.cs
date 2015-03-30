using System;

class String_Variables_Hello_And_World
{
    static void Main()
    {
        string greeting = "Hello";
        string location = "World";
        object fulltext = greeting + " " + location;
        string stringtext = (string)fulltext;
        Console.WriteLine(stringtext);
    }
}