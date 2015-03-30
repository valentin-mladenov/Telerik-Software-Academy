namespace _3.Set_Of_Words_InTextFile
{
    using System.Collections.Generic;

    public class Node
    {
        public Node()
        {
            this.Edges = new Dictionary<Letter, Node>();
        }

        public Dictionary<Letter, Node> Edges { get; set; }

        public string Word { get; set; }

        public bool IsTerminal
        {
            get
            {
                return Word != null;
            }
        }
    }
}