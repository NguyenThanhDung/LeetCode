using System.Text;

public class Problem2663
{
    public Problem2663()
    {
        Console.WriteLine(SmallestBeautifulString("abcz", 26).Equals("abda"));
        Console.WriteLine(SmallestBeautifulString("dc", 4).Equals(""));
        Console.WriteLine(SmallestBeautifulString("ced", 6).Equals("cef"));
        Console.WriteLine(SmallestBeautifulString("cegaf", 7).Equals("cegba"));
        Console.WriteLine(SmallestBeautifulString("e", 6).Equals("f"));
        Console.WriteLine(SmallestBeautifulString("e", 5).Equals(""));
    }

    public string SmallestBeautifulString(string s, int k)
    {
        char lastChar = (char)(((int)'a') + k - 1);
        string lastString = new String(lastChar, s.Length);

        bool isBeautiful = false;
        while (s.Equals(lastString) == false)
        {
            s = IncreaseOneUnit(s, k);
            isBeautiful = IsBeautiful(s);
            if (isBeautiful)
                break;
        }

        return isBeautiful ? s : "";
    }

    private string IncreaseOneUnit(string s, int k)
    {
        StringBuilder sbResult = new StringBuilder();
        bool shouldIncrease = true;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char nextChar = (char)(((int)s[i]) + (shouldIncrease ? 1 : 0));
            int charIndex = nextChar - 'a';
            if (charIndex >= k)
            {
                nextChar = 'a';
                shouldIncrease = true;
            }
            else
            {
                shouldIncrease = false;
            }
            sbResult.Insert(0, nextChar);
        }
        return sbResult.ToString();
    }

    private bool IsBeautiful(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                string subString = s.Substring(i, j - i + 1);
                if (IsPalindrome(subString))
                    return false;
            }
        }
        return true;
    }

    private bool IsPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
                return false;
        }
        return true;
    }
}
