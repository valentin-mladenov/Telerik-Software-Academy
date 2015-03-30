using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Write a program that parses an URL address given in the format:
//[protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource]
//elements. For example from the URL
//http://www.devbg.org/forum/index.php 
//the following information should be extracted:
//[protocol] = "http"
//[server] = "www.devbg.org"
//[resource] = "/forum/index.php"



class URL_Parsing
{
    static void Main()
    {
        //string address = "http://www.devbg.org/forum/index.php";
        //Console.WriteLine("\"{0}\"", address);
        string address = Console.ReadLine();
        //Console.WriteLine("\"{0}\"", address);

        string pattern = @"://|(/+?)" ;
        string[] parts = Regex.Split(address, pattern);

        string protocol = parts[0];        
        string server = parts[1];        
        StringBuilder resourse = new StringBuilder(parts.Length - 2);
        for (int i = 2; i < parts.Length; i++)
        {
            resourse.Append(parts[i]);
        }
        resourse.ToString();

        Console.WriteLine("[protocol] = \"{0}\"", protocol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resourse);
    }
}