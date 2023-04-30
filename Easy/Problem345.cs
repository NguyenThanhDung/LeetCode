public class Problem345
{
    public Problem345()
    {
        Console.WriteLine(ReverseVowels("hello").Equals("holle"));
        Console.WriteLine(ReverseVowels("leetcode").Equals("leotcede"));
        Console.WriteLine(ReverseVowels("a.").Equals("a."));
    }

    public string ReverseVowels(string s)
    {
        List<char> reverse = new List<char>();
        int j = s.Length - 1;
        for (int i = 0; i < s.Length; i++)
        {
            if (IsVowels(s[i]))
            {
                while (j >= 0 && IsVowels(s[j]) == false)
                    j--;
                if (IsVowels(s[j]))
                {
                    reverse.Add(s[j]);
                    j--;
                }
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