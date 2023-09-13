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
        List<int> sortedSatisfaction = satisfaction.ToList();
        sortedSatisfaction.Sort();

        int maxSatisfaction = 0;
        while (sortedSatisfaction.Count > 0)
        {
            int currentSatisfaction = CalculateSatisfaction(sortedSatisfaction);
            if (maxSatisfaction < currentSatisfaction)
            {
                maxSatisfaction = currentSatisfaction;
            }
            sortedSatisfaction.RemoveAt(0);
        }
        return maxSatisfaction;
    }

    private int CalculateSatisfaction(List<int> satisfaction)
    {
        int sum = 0;
        for (int i = 0; i < satisfaction.Count; i++)
        {
            sum += (i + 1) * satisfaction.ElementAt(i);
        }
        return sum;
    }
}