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
    public void TestGetWordsFor1()
    {
        var words = trie.GetWordsFor("tes");
        Assert.AreEqual(2, words.Count);
        Assert.Contains("test", words);
        Assert.Contains("testing", words);
    }

    [Test]
    public void TestGetWordsFor2()
    {
        var words = trie.GetWordsFor("li");
        Assert.Zero(words.Count);
    }

    [Test]
    public void TestGetWordsFor3()
    {
        var words = trie.GetWordsFor("entering");
        Assert.Zero(words.Count);
    }
}