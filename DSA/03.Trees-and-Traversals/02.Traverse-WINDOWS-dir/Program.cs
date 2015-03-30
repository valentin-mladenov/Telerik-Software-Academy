// Write a program to traverse the directory C:\WINDOWS and all
// its subdirectories recursively and to display all files matching
// the mask *.exe. Use the class System.IO.Directory.

// This is my first time i do something like this
// i get help from the net for this one.
namespace _02.Traverse_WINDOWS_dir
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TraverseDirectory
    {
        public static IList<string> FindFilesWithExtentions(DirectoryInfo directory, string pattern)
        {
            IList<string> files = new List<string>();
            FindFiles(directory, pattern, files);

            return files;
        }

        private static void FindFiles(DirectoryInfo directory, string pattern,
            IList<string> files)
        {
            if (directory == null)
            {
                return;
            }

            try
            {
                var currentDirectoryFiles = directory.GetFiles(pattern);
                foreach (var file in currentDirectoryFiles)
                {
                    files.Add(file.FullName);
                }
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (var subdir in subDirectories)
                {
                    FindFiles(subdir, pattern, files);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("{0} Not accessible!", directory.FullName);
                return;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            List<string> winDirExecutables = new List<string>();
            winDirExecutables = (List<string>) TraverseDirectory.FindFilesWithExtentions(new DirectoryInfo(@"C:\WINDOWS"), "*.exe");

            foreach (var file in winDirExecutables)
            {
                Console.WriteLine(file);
            }

        }
    }
}
