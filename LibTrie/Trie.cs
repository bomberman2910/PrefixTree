using System.Collections.Generic;

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

    public List<string> GetWordsFor(string startOfWord)
    {
        var result = new List<string>();
        var charsOfStart = startOfWord.ToCharArray();
        if(charsOfStart.Length < 1 || !baseNode.HasChild(charsOfStart[0]))
            return result;
        var nodeForStart = FindNode(charsOfStart);
        if(nodeForStart is null)
            return result;
        result.AddRange(nodeForStart.GetAllWords(startOfWord));
        return result;
    }

    private Node FindNode(char[] chars)
    {
        if(!baseNode.HasChild(chars[0]))
            return null;
        var currentNode = baseNode.GetChild(chars[0]);
        for (int i = 1; i < chars.Length; i++)
        {
            if(!currentNode.HasChild(chars[i]))
                return null;
            currentNode = currentNode.GetChild(chars[i]);
        }
        return currentNode;
    }

}

