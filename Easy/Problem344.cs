public class Problem344
{
    public Problem344()
    {
        char[] s = new char[] { 'h', 'e', 'l', 'l', 'o' };
        ReverseString(s);
        Console.WriteLine(AreEquals(s, new char[] { 'o', 'l', 'l', 'e', 'h' }));
    }

    private bool AreEquals(char[] s1, char[] s2)
    {
        if (s1.Length != s2.Length)
            return false;
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
                return false;
        }
        return true;
    }

    public void ReverseString(char[] s)
    {
        char t = '\0';
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            t = s[i];
            s[i] = s[j];
            s[j] = t;
        }
    }
}