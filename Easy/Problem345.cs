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
        Stack<char> reverseVowels = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
            if (IsVowels(s[i]))
                reverseVowels.Push(s[i]);

        List<char> result = new List<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (IsVowels(s[i]))
                result.Add(reverseVowels.Pop());
            else
                result.Add(s[i]);
        }

        return new string(result.ToArray());
    }

    private bool IsVowels(char c)
    {
        return "aeiou".Contains(c.ToString().ToLower());
    }
}