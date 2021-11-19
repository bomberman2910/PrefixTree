using System.Collections.Generic;

namespace LibTrie
{
    public class Node
    {
        private Dictionary<char, Node> children = new();

        public bool IsWord { get; set; }
        public Node this[char c]
        {
            get
            {
                if (!children.ContainsKey(c))
                    children.Add(c, new Node());
                return children[c];
            }
        }

        public void AddWord(char[] splitWord)
        {
            if (splitWord.Length == 0)
            {
                IsWord = true;
                return;
            }
            this[splitWord[0]].AddWord(splitWord[1..]);
        }
    }
}
