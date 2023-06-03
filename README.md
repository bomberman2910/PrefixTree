# Prefix tree in C\#

[![.NET](https://github.com/bomberman2910/PrefixTree/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bomberman2910/PrefixTree/actions/workflows/dotnet.yml)

Basic implementation of a prefix tree (also called Trie) in C# for use in other projects.

## Getting Started

### Dependencies

* .NET 5.0
* any platform where .NET 5 is a thing

### Usage

* add LibTrie to your project
* create a new ```Trie``` instance with ```var trie = new Trie();```
* add new words to it with ```trie.AddWord("example");```
* to get all words starting with a certain substring, use ```List<string> words = trie.GetWordsFor("prefix");```
  * if there are no words in the trie beginning with that substring the method will return an empty list

### Demo app

```LibTreeDemo``` is a small console app showcasing an example for using this library. There are two word lists included with the project, but you can use any list as long as the words contain only letters and are all separated by line breaks. To use the application you have to give the path to your word list as an argument. After loading the words you'll be presented with an empty console expecting you to type characters. After entering a character up to ten words contained inside the Trie, that starting with your input, will be displayed underneath the input, kind of mimicking an autocomplete textbox.

#### Sources for word list files

* [MIT's 10000-word list](https://www.mit.edu/~ecprice/wordlist.10000)
* [dwyl/english-words on GitHub](https://github.com/dwyl/english-words)

## Authors

* bomberman2910

## License

This project is licensed under the MIT License - see the LICENSE file for details.
