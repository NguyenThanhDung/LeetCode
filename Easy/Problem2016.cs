public class Problem2016
{
    public Problem2016()
    {
        Console.WriteLine(MaximumDifference(new int[]{7, 1, 5, 4}) == 4);
        Console.WriteLine(MaximumDifference(new int[]{9, 4, 3, 2}) == -1);
        Console.WriteLine(MaximumDifference(new int[]{1, 5, 2, 10}) == 9);
    }

    public int MaximumDifference(int[] nums) {
        int maxDiff = -1;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                {
                    int diff = nums[j] - nums[i];
                    if (diff > maxDiff)
                        maxDiff = diff;
                }
            }
        }
        return maxDiff;
    }
}