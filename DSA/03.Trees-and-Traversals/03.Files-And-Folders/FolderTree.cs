namespace _03.Files_And_Folders
{
    using System;
    using System.IO;
  
    class FolderTree
    {
        private Folder root;

        public Folder Root
        {
            get
            {
                return this.root;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root cannot be null!");
                }
                this.root = value;
            }
        }

        public FolderTree(Folder root)
        {
            this.Root = root;
        }

        public void CreateTree(DirectoryInfo directory)
        {
            SaveAllFilesAndFolders(directory, this.Root);
        }

        private void SaveAllFilesAndFolders(DirectoryInfo directory, Folder rootFolder)
        {
            if (directory == null)
            {
                return;
            }

            try
            {
                FileInfo[] currentDirectoryFiles = directory.GetFiles();
                foreach (var file in currentDirectoryFiles)
                {
                    File myfile = new File(file.Name, file.Length);
                    rootFolder.AddFile(myfile);
                }

                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (var subdir in subDirectories)
                {
                    Folder myfolder = new Folder(subdir.Name);
                    rootFolder.AddFolder(myfolder);
                    SaveAllFilesAndFolders(subdir, myfolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("{0} Not accessible!", directory.FullName);
                return;
            }
        }

        public decimal CalculateWholeTreeSize()
        {
            decimal sum = 0;
            CalculateFolderSize(this.Root, ref sum);
            return sum;
        }

        public decimal CalculateSubTreeSize(string folderName)
        {
            if (this.Root == null)
            {
               throw new ArgumentNullException("The tree has no root!");
            }

            decimal sum = 0;
            if (this.Root.Name == folderName)
            {
                this.CalculateFolderSize(this.Root, ref sum);
            }
            else
            {
                this.TraverseDFSForSubFolderSum(this.Root, folderName, ref sum);
            }
            return sum;
        }

        private void TraverseDFSForSubFolderSum(Folder root, string folderName,ref decimal sum)
        {
            // Console.WriteLine(spaces + root.Data);

            Folder child = null;
            for (int i = 0; i < root.Folders(); i++)
            {
                child = root.GetChildFolderAtIndex(i);
                if (child.Name == folderName)
                {
                    this.CalculateFolderSize(child,ref sum);
                }
                this.TraverseDFSForSubFolderSum(child, folderName, ref sum);
            }
        }

        public void CalculateFolderSize(Folder folder, ref decimal sum)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("Folder cannot be null!");
            }
            for (int i = 0; i < folder.GetAllFiles().Count; i++)
            {
                if (folder.GetAllFiles()[i] != null)
                {
                    sum += folder.GetAllFiles()[i].Size;
                }
            }
            for (int i = 0; i < folder.GetAllFolders().Count; i++)
            {
                Folder currentFolder = folder.GetChildFolderAtIndex(i);
                CalculateFolderSize(currentFolder, ref sum);
            }
        }
    }
}
