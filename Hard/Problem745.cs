public class Problem745
{
    public Problem745()
    {
        string[] words = new string[] { "apple" };
        WordFilter wordFilter = new WordFilter(words);
        int index = wordFilter.F("a", "e");
        Console.WriteLine(index == 0);

        words = new string[] { "WordFilter" };
        wordFilter = new WordFilter(words);
        index = wordFilter.F("f", "");
        Console.WriteLine(index == -1);
    }

    public class WordFilter
    {
        private string[] words;

        public WordFilter(string[] words)
        {
            this.words = words;
        }

        public int F(string pref, string suff)
        {
            int index = -1;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i].StartsWith(pref) && words[i].EndsWith(suff))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}