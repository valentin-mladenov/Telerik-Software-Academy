// Task 07: In a text file we are given the name, address and phone number
// of given person (each at a single line). Write a program, which creates
// new XML document, which contains these data in structured XML format.

namespace _07.XML_From_Text_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    class XMLFromTextFile
    {
        private static void Main()
        {
            Encoding encoding = Encoding.GetEncoding(1251);
            string textfile = @"..\..\Contacts.txt";
            StreamReader reader = new StreamReader(textfile, encoding);
            var xPersons = new List<XElement>();

            using (reader)
            {
                int count = 1;
                string name = "";
                string address = "";
                string phone = "";

                var line = reader.ReadLine();
                while (line != null)
                {
                    if (count == 1)
                    {
                        name = line;
                        count++;
                    }
                    else if (count == 2)
                    {
                        address = line;
                        count++;
                    }
                    else
                    {
                        phone = line;
                        var xPerson = new XElement(
                            "person",
                            new XElement("name", name),
                            new XElement("address", address),
                            new XElement("phone", phone));
                        xPersons.Add(xPerson);
                        count = 1;
                    }

                    line = reader.ReadLine();
                }
            }

            var xResult = new XElement("persons", xPersons);
            Console.WriteLine(xResult);
            xResult.Save(@"..\..\Contacts.xml");
        }
    }
}
