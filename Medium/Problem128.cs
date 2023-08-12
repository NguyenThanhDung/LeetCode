public class Problem128
{
    public Problem128()
    {
        Console.WriteLine(LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }) == 4);
        Console.WriteLine(LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }) == 9);
        Console.WriteLine(LongestConsecutive(new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 }) == 7);
    }

    public int LongestConsecutive(int[] nums)
    {
        Dictionary<int, int> distinctNums = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!distinctNums.ContainsKey(n))
                distinctNums.Add(n, 0);
        }

        Dictionary<int, int> ranges = new Dictionary<int, int>();
        foreach (var n in distinctNums.Keys)
        {
            int minOfPossibleSequence = n - distinctNums.Keys.Count + 1;
            int maxOfPossibleSequence = n + distinctNums.Keys.Count - 1;
            for (int i = minOfPossibleSequence; i <= maxOfPossibleSequence; i++)
            {
                if (ranges.ContainsKey(i))
                    ranges[i]++;
                else
                    ranges.Add(i, 1);
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