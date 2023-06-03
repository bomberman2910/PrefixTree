using System.Collections.Generic;

namespace LibTrie;

internal class Node
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

    public bool HasChild(char character)
    {
        return children.ContainsKey(character);
    }

    public Node GetChild(char character)
    {
        if(!children.ContainsKey(character))
            return null;
        return children[character];
    }

    public List<string> GetAllWords(string startOfWord)
    {
        var result = new List<string>();
        if(IsWord)
            result.Add(startOfWord);
        foreach (var (character, node) in children)
            result.AddRange(node.GetAllWords($"{startOfWord}{character}"));
        return result;
    }
}

