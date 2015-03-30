// Task 04: Using the DOM parser write a program to delete from
// catalog.xml all albums having price > 20.

namespace _04.Delete_All_Avbove_20
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class DeleteAllAvbove20UsingDOM
    {
        static void Main()
        {
            var catalogue = new XmlDocument();
            catalogue.Load("../../Catalogue.xml");

            XmlNode rootNode = catalogue.DocumentElement;

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                if (decimal.Parse(album["price"].InnerText) > 20M)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }

            catalogue.Save("../../NewCatalogue.xml");
            Console.WriteLine("New xml in NewCatalogue.xml");
        }
    }
}
