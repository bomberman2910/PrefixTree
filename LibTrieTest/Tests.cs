using NUnit.Framework;

namespace LibTrieTest;

public class Tests
{
    private LibTrie.Trie trie = new LibTrie.Trie();

    [SetUp]
    public void Setup()
    {
        trie.AddWord("test");
        trie.AddWord("trying");
        trie.AddWord("enter");
        trie.AddWord("testing");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}