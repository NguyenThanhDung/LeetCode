public class Problem009
{
    public Problem009()
    {
        Console.WriteLine(IsPalindrome(121) == true);
        Console.WriteLine(IsPalindrome(-121) == false);
        Console.WriteLine(IsPalindrome(10) == false);
    }

    public bool IsPalindrome(int x) {
        String strX = x.ToString();
        for(int i = 0, j = strX.Length - 1; i < j; i++, j--)
            if(strX[i] != strX[j])
                return false;
        return true;
    }
}