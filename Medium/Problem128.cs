public class Problem128
{
    public Problem128()
    {
        Console.WriteLine(LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }) == 4);
        Console.WriteLine(LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }) == 9);
    }

    public int LongestConsecutive(int[] nums)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            int minOfPossibleSequence = n - nums.Length + 1;
            int maxOfPossibleSequence = n + nums.Length - 1;
            for (int i = minOfPossibleSequence; i <= maxOfPossibleSequence; i++)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i, 1);
            }
        }
        int maxValue = int.MinValue;
        foreach (var pair in dict)
        {
            if (pair.Value > maxValue)
                maxValue = pair.Value;
        }
        return maxValue;
    }
}