public class Problem345
{
    public Problem345()
    {
        Console.WriteLine(ReverseVowels("hello"));  // holle
        Console.WriteLine(ReverseVowels("leetcode"));    // leotcede
    }

    public string ReverseVowels(string s)
    {
        List<char> reverse = new List<char>();
        int j = s.Length - 1;
        for (int i = 0; i < s.Length; i++)
        {
            if (IsVowels(s[i]))
            {
                while (j > 1 && IsVowels(s[j]) == false)
                    j--;
                reverse.Add(s[j]);
                j--;
            }
            else
            {
                reverse.Add(s[i]);
            }
        }
        return new string(reverse.ToArray());
    }

    private bool IsVowels(char c)
    {
        return "aeiou".Contains(c.ToString().ToLower());
    }
}