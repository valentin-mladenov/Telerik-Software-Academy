using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Max_Length_String
{
    static void Main()
    {
        string[] strArr = new string[] 
        { 
            "werthjiujk"
            , "Collections"
            , "Threading"
            , "System.Threading.Tasks;"
            , "1" 
            , "Pulni marmaladi s 4esan i luti 4ushki"
        };

        string max=string.Empty;
        var result = from str in strArr
                        where str.Length == strArr.Max(x=>x.Length)
                        select str;
        Console.WriteLine(string.Join("",result));
    }
}