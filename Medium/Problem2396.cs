using System.Text;

public class Problem2396
{
    public Problem2396()
    {
        Console.WriteLine(IsStrictlyPalindromic(9) == false);
        Console.WriteLine(IsStrictlyPalindromic(4) == false);
    }

    public bool IsStrictlyPalindromic(int n)
    {
        for (int b = 2; b <= (n - 2); b++)
        {
            string strNum = Base10ToBaseB(n, b);
            if (!IsPalindromic(strNum))
                return false;
        }
        return true;
    }

    private string Base10ToBaseB(int n, int b)
    {
        StringBuilder sb = new StringBuilder();
        while (n > 0)
        {
            sb.Insert(0, (n % b).ToString());
            n /= b;
        }
        return sb.ToString();
    }

    private bool IsPalindromic(string num)
    {
        for (int i = 0, j = num.Length - 1; i < j; i++, j--)
        {
            if (num[i] != num[j])
                return false;
        }
        return true;
    }
}