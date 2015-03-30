namespace _03.Files_And_Folders
{
    public class File
    {
        public File(string name, decimal size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }
        public decimal Size { get; set; }
    }
}
