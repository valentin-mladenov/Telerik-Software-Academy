// Define classes File { string name, int size } and Folder { string name, File[]
// files, Folder[] childFolders } and using them build a tree keeping all files and
// folders on the hard drive starting from C:\WINDOWS. Implement a method that
// calculates the sum of the file sizes in given subtree of the tree and test
// it accordingly. Use recursive DFS traversal.

namespace _03.Files_And_Folders
{
    using System;
    using System.IO;

    class FilesAndFolders
    {
        static void Main()
        {
            Console.WriteLine("IT WILL HANG COZ WINDOWS FOLDER IS QUITE BIG");
            Folder windowsFolder = new Folder("WINDOWS");
            FolderTree folderTree = new FolderTree(windowsFolder);
            folderTree.CreateTree(new DirectoryInfo(@"C:\WINDOWS"));

            decimal sum = folderTree.CalculateWholeTreeSize();

            Console.WriteLine("This is the size of all accessed folders and files");
            Console.WriteLine("{0} bytes", sum);
            Console.WriteLine("{0:F2} MB", sum / 1024 / 1024);

            decimal sumSubTree = folderTree.CalculateSubTreeSize("ADFS");

            Console.WriteLine("This is the size of sub folder ADFS");
            Console.WriteLine("{0} bytes", sumSubTree);
            Console.WriteLine("{0:F2} MB", sumSubTree / 1024 / 1024);
        }
    }
}
