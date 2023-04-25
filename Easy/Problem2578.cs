public class Problem2578
{
    public Problem2578()
    {
        Console.WriteLine(SplitNum(4325) == 59);
        Console.WriteLine(SplitNum(687) == 75);
    }

    public int SplitNum(int num)
    {
        int[] digitArray = num.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).OrderDescending().ToArray();
        int minSum = 0;
        int f = 1;
        for (int i = 0; i < digitArray.Length; i++)
        {
            minSum += digitArray[i] * f;
            if (i % 2 == 1)
                f *= 10;
        }
        return minSum;
    }
}