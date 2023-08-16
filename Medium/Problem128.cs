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
        HashSet<int> distinctNums = new HashSet<int>();
        foreach (var n in nums)
        {
            if (!distinctNums.Contains(n))
                distinctNums.Add(n);
        }

        int maxSequenceLength = 0;
        foreach (var n in distinctNums)
        {
            if (distinctNums.Contains(n - 1))
                continue;
            int sequenceLength = 0;
            while (distinctNums.Contains(n + sequenceLength))
                sequenceLength++;
            if (maxSequenceLength < sequenceLength)
                maxSequenceLength = sequenceLength;
        }
        return maxSequenceLength;
    }
}