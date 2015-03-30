namespace AllCatalogueTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;

    using Saxon.Api;

    public class CatalogueOfAlbums
    {
        // Task 02:
        public static void ExtractAllDiferentArtistsUsingDOM(XmlDocument catalogue)
        {
            var artistDict = new Dictionary<string, int>();
            XmlNode rootNode = catalogue.DocumentElement;

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                if (!artistDict.ContainsKey(album["artist"].InnerText))
                {
                    artistDict.Add(album["artist"].InnerText, 1);
                }
                else
                {
                    artistDict[album["artist"].InnerText]++;
                }
            }

            Console.WriteLine("Task 02: Artists Using DOM");
            Console.WriteLine(string.Join(", ", artistDict));
        }

        // Task 03:
        public static void ExtractAllDiferentArtistsUsingXPath(XmlDocument catalogue)
        {
            var artistDict = new Dictionary<string, int>();
            string xPathQuery = "/catalogue/album";

            XmlNodeList artistList = catalogue.SelectNodes(xPathQuery);

            foreach (XmlNode album in artistList)
            {
                XmlNode artist = album.SelectSingleNode("artist");

                if (!artistDict.ContainsKey(artist.InnerText))
                {
                    artistDict.Add(artist.InnerText, 1);
                }
                else
                {
                    artistDict[artist.InnerText]++;
                }
            }

            Console.WriteLine("Task 02: Artists Using XPath");
            Console.WriteLine(string.Join(", ", artistDict));
        }

        // Task 05:
        public static void ExtractAllSongTitlesUsingXmlReader(XmlReader reader)
        {
            var songTitles = new List<string>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "song")
                {
                    reader.Read();
                    songTitles.Add(reader.ReadElementString());
                }
            }

            Console.WriteLine("Task 05: Songs Using XmlReader");
            Console.WriteLine(string.Join(", ", songTitles));
        }

        // Task 06:
        public static void ExtractAllSongTitlesUsingXDocument(XDocument catalogueXD)
        {
            var songs = from song in catalogueXD.Descendants("song") select new { Title = song.Element("title").Value };

            Console.WriteLine("Task 06: ");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }

        // task 08:
        public static void CreateAlbumfromCatalog()
        {
            var artistDict = new SortedDictionary<string, List<string>>();
            using (var reader = XmlReader.Create("../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        var title = reader.ReadElementString();
                        reader.Read();
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "artist")
                        {
                            var artist = reader.ReadElementString();
                            var titles = new List<string>();
                            titles.Add(title);

                            if (!artistDict.ContainsKey(artist))
                            {
                                artistDict.Add(artist, titles);
                            }
                            else
                            {
                                artistDict[artist].Add(title);
                            }
                        }
                    }
                }
            }

            string fileName = "../../Album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                Console.WriteLine("Task 08: ");
                foreach (var album in artistDict)
                {
                    foreach (var title in album.Value)
                    {
                        writer.WriteStartElement("album");
                        writer.WriteElementString("name", title);
                        writer.WriteElementString("artist", album.Key);
                        writer.WriteEndElement();
                        Console.WriteLine("Album:" + title + " from " + album.Key);
                    }
                }

                writer.WriteEndDocument();
            }
        }

        // Task 11:
        public static void PricesOfAlbumsBefore5YearsXPath(XmlDocument catalogue)
        {
            var artistDict = new Dictionary<string, string>();
            string xPathQuery = "/catalogue/album";

            XmlNodeList albumList = catalogue.SelectNodes(xPathQuery);

            foreach (XmlNode album in albumList)
            {
                if (int.Parse(album.SelectSingleNode("year").InnerText) <= 2009)
                {
                    XmlNode price = album.SelectSingleNode("price");
                    XmlNode title = album.SelectSingleNode("title");
                    artistDict.Add(title.InnerText, price.InnerText);
                }
            }

            Console.WriteLine("Task 11: Prices of albums 5 years ago");
            Console.WriteLine(string.Join(", ", artistDict));
        }

        // Task 12: 
        public static void PricesOfAlbumsBefore5YearsLINQ(XDocument catalogue)
        {
            var songs = from article in catalogue.Descendants("album")
                        where int.Parse(article.Element("year").Value) < 2009
                        select new 
                        { 
                            Title = article.Element("title").Value,
                            Price = article.Element("price").Value 
                        };

            Console.WriteLine("Task 12: ");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title + " price: " + song.Price);
            }
        }

        // Task 13:
        public static void XslTransformatorFromXml()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../Catalogue.xslt");
            xslt.Transform("../../Catalogue.xml", "../../Catalogue.html");
        }

        public static void XslTransformatorFromXmlWithXQuery()
        {
            //var expr = "fwgerghehgre";
            //var dd = new XQueryCompiler(new Processor(new Stream("../../Catalogue.xml")));
            //dd.XQueryLanguageVersion.Length;

            //var xquery = new XQueryExecutable();
            //xquery.
        }

        public static void Main()
        {
            var catalogue = new XmlDocument();
            catalogue.Load("../../Catalogue.xml");

            // Task01: Creation of Catalogue info in file.

            // Task02: Write program that extracts all different artists which are
            // found in the catalog.xml. For each author you should print the
            // number of albums in the catalogue. Use the DOM parser and a hash-table.
            ExtractAllDiferentArtistsUsingDOM(catalogue);
            Console.WriteLine();

            // Task03: Implement the previous using XPath.
            ExtractAllDiferentArtistsUsingXPath(catalogue);
            Console.WriteLine();

            // Task05: Write a program, which using XmlReader
            // extracts all song titles from catalog.xml.
            using (XmlReader reader = XmlReader.Create("../../Catalogue.xml"))
            {
                ExtractAllSongTitlesUsingXmlReader(reader);
                Console.WriteLine();
            }

            // Task 06: Rewrite the same using XDocument and LINQ query.
            XDocument catalogueXD = XDocument.Load("../../Catalogue.xml");
            ExtractAllSongTitlesUsingXDocument(catalogueXD);
            Console.WriteLine();

            // Task 08: Write a program, which (using XmlReader and XmlWriter)
            // reads the file catalog.xml and creates the file album.xml, in which
            // stores in appropriate way the names of all albums and their authors.
            CreateAlbumfromCatalog();
            Console.WriteLine();

            // Task 11: Write a program, which extract from the file catalog.xml
            // the prices for all albums, published 5 years ago or earlier.
            // Use XPath query
            PricesOfAlbumsBefore5YearsXPath(catalogue);
            Console.WriteLine();

            // Task 12: Rewrite the previous using LINQ query.
            PricesOfAlbumsBefore5YearsLINQ(catalogueXD);
            Console.WriteLine();

            // Task 13: Create an XSL stylesheet, which transforms the file catalog.xml
            // into HTML document, formatted for viewing in a standard Web-browser.

            // Task 14: Write a C# program to apply the XSLT stylesheet transformation
            // on the file catalog.xml using the class XslTransform.
            XslTransformatorFromXml();

            // *
            // Task 15: Read some tutorial about the XQuery language. Implement the XML
            // to HTML transformation with XQuery (instead of XSLT). Download some open
            // source XQuery library for .NET and execute the XQuery to transform the
            // catalog.xml to HTML.
            // I read a lot of this XQuery, but I din't have the time to make it work :(s.
            XslTransformatorFromXmlWithXQuery();

            // Task 16: Using Visual Studio generate an XSD schema for the file catalog.xml.
            // Write a C# program that takes an XML file and an XSD file (schema) and
            // validates the XML file against the schema. Test it with valid XML
            // catalogs and invalid XML catalogs.
            // DONE. Check both files.
        }
    }
}