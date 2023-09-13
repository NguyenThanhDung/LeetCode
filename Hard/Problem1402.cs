public class Problem1402
{
    public Problem1402()
    {
        Console.WriteLine(MaxSatisfaction(new int[] { -1, -8, 0, 5, -9 }) == 14);
        Console.WriteLine(MaxSatisfaction(new int[] { 4, 3, 2 }) == 20);
        Console.WriteLine(MaxSatisfaction(new int[] { -1, -4, -5 }) == 0);
    }

    public int MaxSatisfaction(int[] satisfaction)
    {
        Array.Sort(satisfaction);

        int maxSatisfaction = 0;
        int sum = 0;
        int currentSum = 0;
        for(int i = satisfaction.Length - 1; i >= 0; i--)
        {
            currentSum += satisfaction[i];
            sum += currentSum;
            if (maxSatisfaction < sum)
            {
                maxSatisfaction = sum;
            }
        }
        return maxSatisfaction;
    }
}