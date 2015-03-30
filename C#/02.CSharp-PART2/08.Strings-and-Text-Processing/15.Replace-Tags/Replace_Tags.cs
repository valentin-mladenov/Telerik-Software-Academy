using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that replaces in
//a HTML document given as string 
//all the tags <a href="…">…</a>
//with corresponding tags [URL=…]…/URL]. 

class Replace_Tags
{
    static void Main()
    {
        //string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        string text = Console.ReadLine();
        
        string startTag = "<a href";
        string startClose = "\">";
        string endTag = "</a>";

        string newStart = "[URL";
        string newClose = "\"]";
        string newEnd = "[/URL]";

        StringBuilder replacing = new StringBuilder(text);
        replacing.Replace(startTag, newStart);
        replacing.Replace(startClose, newClose);
        replacing.Replace(endTag, newEnd);       
        replacing.ToString();

        Console.WriteLine(replacing);
    }
}