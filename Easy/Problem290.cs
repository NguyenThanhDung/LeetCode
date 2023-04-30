public class Problem290
{
    public Problem290()
    {
        Console.WriteLine(WordPattern("abba", "dog cat cat dog") == true);
        Console.WriteLine(WordPattern("abba", "dog cat cat fish") == false);
        Console.WriteLine(WordPattern("aaaa", "dog cat cat dog") == false);
        Console.WriteLine(WordPattern("abba", "dog dog dog dog") == false);
    }

    public bool WordPattern(string pattern, string s)
    {
        string[] sArr = s.Split(" ");

        if (pattern.Length != sArr.Length)
            return false;

        Dictionary<char, string> dict = new Dictionary<char, string>();
        List<string> uniqueAddedStrings = new List<string>();
        for (int i = 0; i < pattern.Length; i++)
        {
            char c = pattern[i];
            string word = sArr[i];

            if (dict.ContainsKey(c))
            {
                string addedWord = dict[c];
                if (word.Equals(addedWord) == false)
                    return false;
            }
            else
            {
                if (uniqueAddedStrings.Contains(word))
                    return false;
                dict.Add(c, word);
                uniqueAddedStrings.Add(word);
            }
        }

        return true;
    }
}