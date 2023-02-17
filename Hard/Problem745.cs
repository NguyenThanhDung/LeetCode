public class Problem745
{
    public Problem745()
    {
        string[] words = new string[] { "apple" };
        WordFilter wordFilter = new WordFilter(words);
        int index = wordFilter.F("a", "e");
        Console.WriteLine(index == 0);
    }

    public class WordFilter
    {
        public WordFilter(string[] words)
        {

        }

        public int F(string pref, string suff)
        {
            return 0;
        }
    }
}