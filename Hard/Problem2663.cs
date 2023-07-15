using System.Text;

public class Problem2663
{
    public Problem2663()
    {
        Console.WriteLine(SmallestBeautifulString("abcz", 26).Equals("abda"));
        Console.WriteLine(SmallestBeautifulString("dc", 4).Equals(""));
    }

    public string SmallestBeautifulString(string s, int k)
    {
        do
        {
            s = IncreaseOneUnit(s, k);
        } while (IsBeautiful(s) == false || s.Equals("") == false);
        return s;
    }

    private string IncreaseOneUnit(string s, int k)
    {
        StringBuilder sbResult = new StringBuilder();
        bool shouldIncrease = true;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char nextChar = (char)(((int)s[i]) + (shouldIncrease ? 1 : 0));
            if (nextChar - 'a' > k)
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
