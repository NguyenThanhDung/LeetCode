public class Problem953
{
    public Problem953()
    {
        Console.WriteLine(IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz") == true);
        Console.WriteLine(IsAlienSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz") == false);
        Console.WriteLine(IsAlienSorted(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz") == false);
    }

    public bool IsAlienSorted(string[] words, string order)
    {
        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (CompareWords(words[i], words[j], order) > 0)
                    return false;
            }
        }
        return true;
    }

    public int CompareWords(string word1, string word2, string order)
    {
        int minLength = (word1.Length < word2.Length) ? word1.Length : word2.Length;
        for (int i = 0; i < minLength; i++)
        {
            int compareValue = order.IndexOf(word1[i]) - order.IndexOf(word2[i]);
            if (compareValue != 0)
                return compareValue;
        }
        return word1.Length - word2.Length;
    }
}