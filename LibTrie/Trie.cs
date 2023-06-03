namespace LibTrie;

public class Trie
{
    private Node baseNode = new Node();

    public void AddWord(string word)
    {
        if (string.IsNullOrEmpty(word))
            return;
        baseNode.AddWord(word.ToCharArray());
    }

}

