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
        char[] reverse = new char[s.Length];
        int j = s.Length - 1;
        for (int i = 0; i < s.Length; i++)
        {
            if (IsVowels(s[i]))
            {
                while (j >= 0 && IsVowels(s[j]) == false)
                    j--;
                if (IsVowels(s[j]))
                {
                    reverse[i] = s[j];
                    j--;
                }
            }
            else
            {
                reverse[i] = s[i];
            }
        }
        return new string(reverse);
    }

    private bool IsVowels(char c)
    {
        return "aeiou".Contains(c.ToString().ToLower());
    }
}