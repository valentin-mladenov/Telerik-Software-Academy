namespace _3.Set_Of_Words_InTextFile
{
    public class Trie
    {
        public Node Root { get; set; }

        public Trie()
        {
            this.Root = new Node();
        }

        public void ReadFile(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                var word = words[w].ToUpperInvariant();
                var node = this.Root;
                for (int len = 1; len <= word.Length; len++)
                {
                    var letter = word[len - 1];
                    Node next;
                    if (!node.Edges.TryGetValue(letter, out next))
                    {
                        next = new Node();
                        if (len == word.Length)
                        {
                            next.Word = word;
                        }
                        node.Edges.Add(letter, next);
                    }
                    node = next;
                }
            }
        }
    }
}