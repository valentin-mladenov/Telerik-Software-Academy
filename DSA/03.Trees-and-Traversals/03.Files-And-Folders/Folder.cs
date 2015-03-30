namespace _03.Files_And_Folders
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        public string Name { get; set; }
        private List<File> files;
        private List<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            files = new List<File>();
            childFolders = new List<Folder>();
        }
        
        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.childFolders.Add(folder);
        }

        public int Files()
        {
            return this.files.Count;
        }

        public int Folders()
        {
            return this.childFolders.Count;
        }

        public List<File> GetAllFiles()
        {
            return this.files;
        }

        public List<Folder> GetAllFolders()
        {
            return this.childFolders;
        }

        public Folder GetChildFolderAtIndex(int index)
        {
            if (index < 0 || index > this.childFolders.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Index is invalid!");
            }
            return this.childFolders[index];
        }
    }
}
