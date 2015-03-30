using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GenericListMain
{
    static void Main()
    {
        GenericList<int> ala = new GenericList<int>(5);
        ala.Add(1);
        Console.WriteLine(ala.ToString());
        ala.AddAtIndex(6, 2);
        Console.WriteLine(ala.ToString());
        ala.Add(7);
        Console.WriteLine(ala.ToString());
        ala.AddAtIndex(3, 5);
        Console.WriteLine(ala.ToString());
        ala.InsertAtIndex(2, 4);
        Console.WriteLine(ala.ToString());
        ala.Add(-1);
        Console.WriteLine(ala.ToString());
        Console.WriteLine(ala.AccessAtIndex(2));
        ala.RemoveAtIndex(7);
        Console.WriteLine(ala.ToString());
        ala.RemoveAtIndex(2);
        Console.WriteLine(ala.ToString());
        Console.WriteLine(ala.FindByValue(3));
        Console.WriteLine(ala.Min<int>());

        GenericList<string> genericList = new GenericList<string>(5);
        genericList.Add("1");
        Console.WriteLine(genericList.ToString());
        genericList.AddAtIndex(6, "2");
        Console.WriteLine(genericList.ToString());
        genericList.Add("7");
        Console.WriteLine(genericList.ToString());
        genericList.AddAtIndex(3, "5");
        Console.WriteLine(genericList.ToString());
        genericList.InsertAtIndex(2, "desfd");
        Console.WriteLine(genericList.ToString());
        genericList.Add("5t");
        Console.WriteLine(genericList.ToString());
        Console.WriteLine(genericList.AccessAtIndex(2));
        genericList.RemoveAtIndex(7);
        Console.WriteLine(genericList.ToString());
        genericList.RemoveAtIndex(2);
        Console.WriteLine(genericList.ToString());
        Console.WriteLine(genericList.Min<string>());

    }
}