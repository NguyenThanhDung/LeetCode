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
            int[] digits = Base10ToBaseB(n, b);
            if (!IsPalindromic(digits))
                return false;
        }
        return true;
    }

    private int[] Base10ToBaseB(int n, int b)
    {
        Stack<int> digits = new Stack<int>();
        while (n > 0)
        {
            digits.Push(n % b);
            n /= b;
        }
        return digits.ToArray();
    }

    private bool IsPalindromic(int[] digits)
    {
        for (int i = 0, j = digits.Length - 1; i < j; i++, j--)
        {
            if (digits[i] != digits[j])
                return false;
        }
        return true;
    }
}