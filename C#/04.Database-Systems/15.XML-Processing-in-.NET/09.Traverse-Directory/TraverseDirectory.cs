namespace _09.Traverse_Directory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    class TraverseDirectory
    {
        private static void FolderXMLWriter(XmlTextWriter writer, Folder folder)
        {
            foreach (var folders in folder.GetAllFolders())
            {
                if (folders.GetAllFolders().Count >= 1)
                {
                    FolderXMLWriter(writer, folders);
                    foreach (var file in folders.GetAllFiles())
                    {
                        writer.WriteElementString("file", file.Name);
                        Console.WriteLine("File:" + file.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Folder: " + folder.Name);
                    writer.WriteElementString("folder", folder.Name);
                    foreach (var file in folders.GetAllFiles())
                    {
                        writer.WriteElementString("file", file.Name);
                        Console.WriteLine("File:" + file.Name);
                    }
                }
            }
        }

        private static void FolderXDocsWriter(XElement xResult, Folder folders)
        {
            foreach (var folder in folders.GetAllFolders())
            {
                if (folder.GetAllFolders().Count >= 1)
                {
                    FolderXDocsWriter(xResult, folder);
                }
                else
                {
                    Console.WriteLine("Folder: " + folder.Name);
                    xResult.Add(new XElement("folder", folder.Name));
                }
            }

            foreach (var file in folders.GetAllFiles())
            {
                xResult.Add(new XElement("file", file.Name));
                Console.WriteLine("File:" + file.Name);
            }
        }

        // Task 09:
        public static void TraverseThisDirectoryWithXmlWriter()
        {
            Folder windowsFolder = new Folder("09.Traverse-Directory");
            FolderTree folderTree = new FolderTree(windowsFolder);
            folderTree.CreateTree(new DirectoryInfo(@"../../"));

            string fileName = "../../CurrentDirXmlWriter.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("dirs");

                foreach (var folder in folderTree.Root.GetAllFolders())
                {
                    if (folder.GetAllFolders().Count >= 1)
                    {
                        FolderXMLWriter(writer, folder);
                    }
                    else
                    {
                        Console.WriteLine("Folder: " + folder.Name);
                        writer.WriteElementString("folder", folder.Name);
                    }

                    foreach (var file in folderTree.Root.GetAllFiles())
                    {
                        writer.WriteElementString("file", file.Name);
                        Console.WriteLine("File:" + file.Name);
                    }
                }

                writer.WriteEndDocument();
            }
        }

        // Task 10:
        public static void TraverseThisDirectoryWithXDocuments()
        {
            Folder windowsFolder = new Folder("09.Traverse-Directory");
            FolderTree folderTree = new FolderTree(windowsFolder);
            folderTree.CreateTree(new DirectoryInfo(@"../../"));

            string fileName = "../../CurrentDirXDoc.xml";

            var xResult = new XElement("dirs");

                foreach (var folder in folderTree.Root.GetAllFolders())
                {
                    if (folder.GetAllFolders().Count >= 1)
                    {
                        FolderXDocsWriter(xResult, folder);
                    }
                    else
                    {
                        Console.WriteLine("Folder: " + folder.Name);
                        xResult.Add(new XElement("folder", folder.Name));
                    }
                }

                foreach (var file in folderTree.Root.GetAllFiles())
                {
                    xResult.Add(new XElement("file", file.Name));
                    Console.WriteLine("File:" + file.Name);
                }

            xResult.Save(fileName);
        }

        static void Main()
        {

            // Task 09: Write a program to traverse given directory and write to a XML file
            // its contents together with all subdirectories and files. Use tags
            // <file> and <dir> with appropriate attributes. For the generation
            // of the XML document use the class XmlWriter
            TraverseThisDirectoryWithXmlWriter();

            // Task 10: Rewrite the last exercises using XDocument, XElement and XAttribute.
            TraverseThisDirectoryWithXDocuments();
        }
    }
}
