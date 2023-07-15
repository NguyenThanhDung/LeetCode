using System.Text;

public class Problem2663
{
    public Problem2663()
    {
        Console.WriteLine(SmallestBeautifulString("abcz", 26).Equals("abda"));
        Console.WriteLine(SmallestBeautifulString("dc", 4).Equals(""));
        Console.WriteLine(SmallestBeautifulString("ced", 6).Equals("cef"));
    }

    public string SmallestBeautifulString(string s, int k)
    {
        char lastChar = (char)(((int)'a') + k - 1);
        string lastString = new String(lastChar, s.Length);

        do
        {
            s = IncreaseOneUnit(s, k);
        } while (IsBeautiful(s) == false && s.Equals(lastString) == false);
        return s.Equals(lastString) ? "" : s;
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
        for (int i = 0; i < s.Length - 2; i++)
        {
            if (s[i] == s[i + 1])
                return false;
        }
        return true;
    }
}
