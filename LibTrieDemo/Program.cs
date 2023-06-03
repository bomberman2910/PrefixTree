using System;
using System.IO;
using LibTrie;

namespace LibTrieDemo;

public class Program
{
    private static string currentInput = string.Empty;

    private static Trie trie = new Trie();

    public static void Main(string[] args)
    {
        if(args.Length != 1)
        {
            Console.WriteLine("Missing word file path");
            Environment.Exit(1);
        }
        if(!File.Exists(args[0]))
        {
            Console.WriteLine("Invalid path for word file");
            Environment.Exit(1);
        }
        var words = File.ReadAllLines(args[0]);
        Console.Write($"Loading words...");
        var counter = 0;
        foreach (var word in words)
        {
            if(string.IsNullOrEmpty(word))
                continue;
            counter++;
            trie.AddWord(word);
        }
        Console.WriteLine("done");
        Console.WriteLine($"Inserted {counter} valid words");
        Console.Clear();
        var readKey = Console.ReadKey();
        while (readKey.Key != ConsoleKey.Escape)
        {
            if (readKey.Key == ConsoleKey.Backspace && currentInput.Length > 0)
            {
                currentInput = currentInput.Remove(currentInput.Length - 1);
                Console.Write(' ');
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            if (char.IsLetter(readKey.KeyChar))
                currentInput += readKey.KeyChar;
            else if(readKey.Key != ConsoleKey.Backspace)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            var savedCursor = Console.GetCursorPosition();
            Console.SetCursorPosition(0, savedCursor.Top + 1);
            for(var i = 0; i < 10; i++)
                Console.WriteLine(new string(' ', 30));
            Console.SetCursorPosition(0, savedCursor.Top + 1);
            var wordsForInput = trie.GetWordsFor(currentInput);
            for(var i = 0; i < (wordsForInput.Count > 10 ? 10 : wordsForInput.Count); i++)
                Console.WriteLine(wordsForInput[i]);
            Console.SetCursorPosition(savedCursor.Left, savedCursor.Top);
            readKey = Console.ReadKey();
        }
        Console.Clear();
    }
}