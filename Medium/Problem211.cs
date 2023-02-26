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
            if (word.Contains("."))
            {
                foreach (string addedWord in this.words)
                {
                    if(CompareWords(addedWord, word))
                        return true;
                }
                return false;
            }
            else
            {
                return this.words.Contains(word);
            }
        }

        public bool CompareWords(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;
            for (int i = 0; i < word1.Length; i++)
            {
                if(word2[i].Equals('.'))
                    continue;
                if(!word1[i].Equals(word2[i]))
                    return false;
            }
            return true;
        }
    }
}
