public class Problem211
{
    public Problem211()
    {
        WordDictionary wordDictionary = new WordDictionary();
        wordDictionary.AddWord("bad");
        wordDictionary.AddWord("dad");
        wordDictionary.AddWord("mad");
        Console.WriteLine(wordDictionary.Search("pad") == false);
        Console.WriteLine(wordDictionary.Search("bad") == true);
        Console.WriteLine(wordDictionary.Search(".ad") == true);
        Console.WriteLine(wordDictionary.Search("b..") == true);
    }

    public class WordDictionary
    {
        private List<String> words;

        public WordDictionary()
        {
            words = new List<string>();
        }

        public void AddWord(string word)
        {
            this.words.Add(word);
        }

        public bool Search(string word)
        {
            if(word.Contains("."))
            {
                return false;
            }
            else
            {
                return this.words.Contains(word);
            }
        }
    }
}
