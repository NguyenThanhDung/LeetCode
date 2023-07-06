public class Problem136
{
    public Problem136()
    {
        Console.WriteLine(SingleNumber(new int[] { 2, 2, 1 }) == 1);
        Console.WriteLine(SingleNumber(new int[] { 4, 1, 2, 1, 2 }) == 4);
        Console.WriteLine(SingleNumber(new int[] { 1 }) == 1);
    }

    public int SingleNumber(int[] nums)
    {
        Dictionary<int, int> appearance = new Dictionary<int, int>();
        foreach (int e in nums)
        {
            if (appearance.ContainsKey(e))
                appearance[e] += 1;
            else
                appearance.Add(e, 1);
        }

        foreach (KeyValuePair<int, int> kvp in appearance)
        {
            if (kvp.Value == 1)
                return kvp.Key;
        }

        return -1;
    }
}

// {2, 2, 1}
// i    nums[i] appearance
// 0    2       {2: 1}
// 1    2       {2: 2}
// 2    1       {2: 2, 1: 1}
