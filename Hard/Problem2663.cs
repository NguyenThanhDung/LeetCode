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
        char[] charArray = s.ToCharArray();
        char lastChar = (char)(((int)'a') + k - 1);

        bool isBeautiful = false;
        while (IsLastString(charArray, lastChar) == false)
        {
            NextLexicographicalString(charArray, k);
            isBeautiful = IsBeautiful(charArray);
            if (isBeautiful)
                break;
        }

        return isBeautiful ? new String(charArray) : "";
    }

    private bool IsLastString(char[] charArray, char lastChar)
    {
        for(int i = 0; i < charArray.Length; i++)
        {
            if(charArray[i] != lastChar)
                return false;
        }
        return true;
    }

    private void NextLexicographicalString(char[] charArray, int k)
    {
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
    }

    private bool IsBeautiful(char[] charArray)
    {
        for (int i = 0; i < charArray.Length - 1; i++)
        {
            for (int j = i + 1; j < charArray.Length; j++)
            {
                if (charArray[i] == charArray[j])
                {
                    bool isPalindrome = true;
                    for (int k = i + 1, l = j - 1; k < l; k++, l--)
                    {
                        if (charArray[k] != charArray[l])
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
