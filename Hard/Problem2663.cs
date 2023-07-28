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
            s = NextLexicographicalString(s, k);
            isBeautiful = IsBeautiful(s);
            if (isBeautiful)
                break;
        }

        return isBeautiful ? s : "";
    }

    private string NextLexicographicalString(string s, int k)
    {
        char[] charArray = s.ToCharArray();
        bool shouldIncrease = true;
        for (int i = charArray.Length - 1; i >= 0; i--)
        {
            char nextChar = (char)(((int)charArray[i]) + (shouldIncrease ? 1 : 0));
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
            charArray[i] = nextChar;
        }
        return new String(charArray);
    }

    private bool IsBeautiful(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    bool isPalindrome = true;
                    for (int k = i + 1, l = j - 1; k < l; k++, l--)
                    {
                        if (s[k] != s[l])
                            isPalindrome = false;
                    }
                    if (isPalindrome)
                        return false;
                }
            }
        }
        return true;
    }
}
