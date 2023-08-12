public class Problem128
{
    public Problem128()
    {
        Console.WriteLine(LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }) == 4);
        Console.WriteLine(LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }) == 9);
    }

    public int LongestConsecutive(int[] nums)
    {
        Dictionary<int, int> processedNums = new Dictionary<int, int>();
        Dictionary<int, int> ranges = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!processedNums.ContainsKey(n))
            {
                processedNums.Add(n, 0);
                int minOfPossibleSequence = n - nums.Length + 1;
                int maxOfPossibleSequence = n + nums.Length - 1;
                for (int i = minOfPossibleSequence; i <= maxOfPossibleSequence; i++)
                {
                    if (ranges.ContainsKey(i))
                        ranges[i]++;
                    else
                        ranges.Add(i, 1);
                }
            }
        }
        int maxValue = int.MinValue;
        foreach (var pair in ranges)
        {
            if (pair.Value > maxValue)
                maxValue = pair.Value;
        }
        return maxValue;
    }
}